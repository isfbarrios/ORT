using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Dominio
{
    public class Seleccion : IComparable<Seleccion>, IValidar
    {
        //Atributos
        private static int autoIncrementId;
        private int id;
        private Pais pais;
        private List<Jugador> jugadores;

        //Constructores
        public Seleccion()
        {
            this.id = ++autoIncrementId;
        }
        public Seleccion(Pais pais)
        {
            this.id = ++autoIncrementId;
            this.pais = pais;
            this.jugadores = new List<Jugador>();
        }

        //Funcionalidades
        public static bool AltaSeleccion(Seleccion seleccion)
        {
            bool retVal = false;
            //Si el pais es valido y tiene al menos once jugadores, lo guardo
            if (seleccion.Validar())
            {
                Administradora.Instance.Selecciones.Add(seleccion);
                retVal = true;
            }
            return retVal;
        }

        public static List<Jugador> ListarJugadores(Pais pais)
        {
            List<Jugador> selJugadores = new List<Jugador>();

            foreach (Jugador j in Administradora.Instance.Jugadores)
            {
                if (j.Pais.Equals(pais)) selJugadores.Add(j);
            }
            return selJugadores;
        }

        public bool JugadoPorEstaSeleccion(Partido partido) => (partido.Local.Equals(this) || partido.Visitante.Equals(this));

        public bool JugadorDeSeleccion(Jugador jugador) => (this.Pais.Equals(jugador.Pais));

        public override string ToString() => ($"{this.Pais.Nombre} [{this.Pais.Codigo}]");

        public static Seleccion GetSeleccion(Jugador jugador)
        {
            Seleccion retVal = null;
            foreach (Seleccion sel in Administradora.Instance.Selecciones)
            {
                if (sel.Pais.Equals(jugador.Pais)) retVal = sel;
            }
            if (retVal == null) retVal = new Seleccion();

            return retVal;
        }

        public bool Validar() => (this.Pais.Validar() && this.Jugadores.Count >= 11);

        public int CompareTo([AllowNull] Seleccion other)
        {
            int retVal = this.Pais.Nombre.CompareTo(other.Pais.Nombre);

            if (retVal == 0) retVal = this.Id.CompareTo(other.Id);

            return retVal;
        }

        //Getters && Setters
        public int Id { get { return this.id; } }
        public Pais Pais { get { return this.pais; } set { this.pais = value; } }
        public List<Jugador> Jugadores { get { return this.jugadores; } }
    }
}

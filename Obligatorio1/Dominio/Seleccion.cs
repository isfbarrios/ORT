using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Dominio
{
    public class Seleccion : IValidar
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
        /// <summary>
        /// Genera el alta de la Seleccion en el sistema.
        /// </summary>
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
        /// <summary>
        /// Retorna todos los jugadores de una selección, a partir del país del jugador.
        /// </summary>
        public static List<Jugador> ListarJugadores(Pais pais)
        {
            List<Jugador> selJugadores = new List<Jugador>();

            foreach (Jugador j in Administradora.Instance.Jugadores)
            {
                if (j.Pais.Equals(pais))  selJugadores.Add(j);
            }
            return selJugadores;
        }
        /// <summary>
        /// Retorna TRUE si la selección jugó este partido (independientemente si era local o visitante).
        /// </summary>
        public bool JugadoPorEstaSeleccion(Partido partido) => (partido.Local.Equals(this) || partido.Visitante.Equals(this));
        /// <summary>
        /// Retorna TRUE si el jugador recibido por parámetro es parte de esta selección.
        /// </summary>
        public bool JugadorDeSeleccion(Jugador jugador) => (this.Pais.Equals(jugador.Pais));
        /// <summary>
        /// Retorna el objecto en formato string.
        /// </summary>
        public override string ToString() => ($"Nombre {this.Pais.Nombre} [{this.Pais.Codigo}]");
        /// <summary>
        /// Retorna la selección a la que el jugador pertenece.
        /// </summary>
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
        /// <summary>
        /// Retorna TRUE o FALSE si la seleccion es valida o no, respectivamente.
        /// </summary>
        public bool Validar() => (!this.Pais.Validar() && this.Jugadores.Count >= 11);

        //Getters && Setters
        public int Id { get { return this.id; } }
        public Pais Pais { get { return this.pais; } set { this.pais = value; } }
        public List<Jugador> Jugadores { get { return this.jugadores; } }
    }
}

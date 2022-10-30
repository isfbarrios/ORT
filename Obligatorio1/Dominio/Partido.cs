﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Partido
    {
        //Atributos
        private static int autoIncrementId;
        private int id;
        private Seleccion local;
        private Seleccion visitante;
        private DateTime fecha;
        private bool finalizado;
        private Resultado resultado;
        private List<Incidente> incidentes;

        //Constructores
        public Partido() 
        {
            this.id = ++autoIncrementId;
        }

        public Partido(Seleccion local, Seleccion visitante, DateTime fecha)
        {
            this.id = ++autoIncrementId;
            this.local = local;
            this.visitante = visitante;
            this.fecha = fecha;
            this.finalizado = false; //Por defecto, no finalizado
            this.resultado = Resultado.PENDIENTE;
            this.incidentes = new List<Incidente>();
        }

        //Funcionalidades
        public static bool AltaPartido(Partido partido)
        {
            bool retVal = false;
            if (Partido.EsPartidoValido(partido))
            {
                Administradora.Instance.Partidos.Add(partido);
                retVal = true;
            }
            return retVal;
        }
        /// <summary>
        /// Retorna TRUE si el partido cumple con la condicion de tener Selecciones validas para Local y Visitante.
        /// </summary>
        public static bool EsPartidoValido(Partido partido)
        {
            return (partido.Local.EsSeleccionValida() && partido.Visitante.EsSeleccionValida());
        }
        /// <summary>
        /// Retorna el partido con más goles, disputado por una seleccion determinada.
        /// </summary>
        public Partido GetPartidos(Seleccion seleccion)
        {
            int golesPartido = 0;
            Partido retPartido = null;
            foreach (Partido partido in Administradora.Instance.Partidos)
            {
                //Si el partido actual tuvo a esta selección como local o visitante, entro.
                if (seleccion.JugadoPorEstaSeleccion(partido))
                {
                    int aux = TotalGolesPartido(partido, seleccion);

                    if (aux >= golesPartido) golesPartido = aux;
                }
            }
            return retPartido;
        }
        /// <summary>
        /// Retorna el listado de partidos disputados por un jugador determinado.
        /// </summary>
        public List<Partido> GetPartidos(Jugador jugador)
        {
            List<Partido> jugadorPartidos = new List<Partido>();

            foreach (Partido partido in Administradora.Instance.Partidos)
            {
                List<Jugador> jugadores = Jugador.TotalJugadoresPartido(partido);

                foreach (Jugador jPartido in jugadores)
                {
                    if (jPartido.Equals(jugador)) jugadorPartidos.Add(partido);
                }
            }
            return jugadorPartidos;
        }
        /// <summary>
        /// Retorna el total de goles de una seleccion, para un partido determinado.
        /// </summary>
        public int TotalGolesPartido(Partido partido, Seleccion seleccion)
        {
            int retVal = 0;
            List<Jugador> jugadores = Jugador.TotalJugadoresPartido(partido);
            //Recorro el listado de jugadores del partido.
            foreach (Jugador jugador in jugadores)
            {
                //Valido que el jugador iterado corresponda a la seleccion que quiero validar.
                if (seleccion.JugadorDeSeleccion(jugador))
                {
                    //Si lo es, valido que tenga incidencias de gol.
                    int auxVal = Incidente.TotalIncidenciasPartido(partido).Count;
                    //Acumulo el resultado.
                    retVal += auxVal;
                }
            }
            return retVal;
        }
        private bool ValidarFechaDePartido()
        {
            bool retVal = false;
            DateTime dateFrom = Convert.ToDateTime("20/11/2022");
            DateTime dateTo = Convert.ToDateTime("18/12/2022");

            if (this.Fecha >= dateFrom && this.Fecha <= dateTo)
            {
                retVal = true;
            }
            return retVal;
        }
        /// <summary>
        /// Retorna el objecto en formato string.
        /// </summary>
        public abstract override string ToString();
        //Getters & Setters
        public int Id
        {
            get { return this.id; }
        }
        public Seleccion Local
        {
            get { return this.local; }
            set { this.local = value; }
        }
        public Seleccion Visitante
        {
            get { return this.visitante; }
            set { this.visitante = value; }
        }
        public DateTime Fecha
        {
            get { return this.fecha; }
        }
        public bool Finalizado
        {
            get { return this.finalizado; }
            set { this.finalizado = value; }
        }
        public Resultado Resultado
        {
            get { return this.resultado; }
            set { this.resultado = value; }
        }
        public List<Incidente> Incidentes
        {
            get { return this.incidentes; }
        }
        /*
        public static void PreLoadPartidos()
        {
            //Partidos de fase de grupos
            //Grupo A - Ganadores Selecciones[0] y Selecciones[3]
            AltaPartido(new Partido(Administradora.Instance.Selecciones[0], Administradora.Instance.Selecciones[1], Utils.RandomDate(), Etapa.FASE_GRUPOS));
            AltaPartido(new Partido(Administradora.Instance.Selecciones[0], Administradora.Instance.Selecciones[2], Utils.RandomDate(), Etapa.FASE_GRUPOS));
            AltaPartido(new Partido(Administradora.Instance.Selecciones[0], Administradora.Instance.Selecciones[3], Utils.RandomDate(), Etapa.FASE_GRUPOS));
            AltaPartido(new Partido(Administradora.Instance.Selecciones[1], Administradora.Instance.Selecciones[2], Utils.RandomDate(), Etapa.FASE_GRUPOS));
            AltaPartido(new Partido(Administradora.Instance.Selecciones[1], Administradora.Instance.Selecciones[3], Utils.RandomDate(), Etapa.FASE_GRUPOS));
            AltaPartido(new Partido(Administradora.Instance.Selecciones[2], Administradora.Instance.Selecciones[3], Utils.RandomDate(), Etapa.FASE_GRUPOS));
            //Grupo B - Ganadores Selecciones[4] y Selecciones[7]
            AltaPartido(new Partido(Administradora.Instance.Selecciones[4], Administradora.Instance.Selecciones[5], Utils.RandomDate(), Etapa.FASE_GRUPOS));
            AltaPartido(new Partido(Administradora.Instance.Selecciones[4], Administradora.Instance.Selecciones[6], Utils.RandomDate(), Etapa.FASE_GRUPOS));
            AltaPartido(new Partido(Administradora.Instance.Selecciones[4], Administradora.Instance.Selecciones[7], Utils.RandomDate(), Etapa.FASE_GRUPOS));
            AltaPartido(new Partido(Administradora.Instance.Selecciones[5], Administradora.Instance.Selecciones[6], Utils.RandomDate(), Etapa.FASE_GRUPOS));
            AltaPartido(new Partido(Administradora.Instance.Selecciones[5], Administradora.Instance.Selecciones[7], Utils.RandomDate(), Etapa.FASE_GRUPOS));
            AltaPartido(new Partido(Administradora.Instance.Selecciones[6], Administradora.Instance.Selecciones[7], Utils.RandomDate(), Etapa.FASE_GRUPOS));
            //Partidos de eliminatorias
            AltaPartido(new Partido(Administradora.Instance.Selecciones[0], Administradora.Instance.Selecciones[7], Utils.RandomDate(), Etapa.OCTAVOS));
            AltaPartido(new Partido(Administradora.Instance.Selecciones[4], Administradora.Instance.Selecciones[3], Utils.RandomDate(), Etapa.OCTAVOS));
        }
        */
    }
}

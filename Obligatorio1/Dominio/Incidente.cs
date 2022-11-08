using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Incidente : IValidar
    {
        //Atributos
        private static int autoIncrementId;
        private int id;
        private Partido partido;
        private Jugador jugador;
        private TipoIncidente tipoIncidente;
        private int minuto;

        //Constructores
        public Incidente() 
        {
            this.id = ++autoIncrementId;
        }

        public Incidente(Partido partido, Jugador jugador, TipoIncidente tipoIncidente, int minuto = -1)
        {
            this.id = ++autoIncrementId;
            this.partido = partido;
            this.jugador = jugador;
            this.tipoIncidente = tipoIncidente;
            this.minuto = minuto;
        }

        public static bool AltaIncidente(Incidente incidente)
        {
            bool retVal = false;
            
            if (incidente.Partido.Validar())
            {
                //Guardo el incidente en la lista genérica y a su vez, en la lista específica de ese partido.
                if (incidente.Validar())
                {
                    retVal = true;
                    incidente.Partido.Incidentes.Add(incidente);
                    Administradora.Instance.Incidentes.Add(incidente);
                }
            }
            return retVal;
        }

        public static bool EsTarjetaRoja(Incidente incidente) => (incidente.TipoIncidente.Equals(TipoIncidente.TARJETA_ROJA));

        public static bool EsTarjetaAmarilla(Incidente incidente) => (incidente.TipoIncidente.Equals(TipoIncidente.TARJETA_AMARILLA));

        public static bool EsGol(Incidente incidente) => (incidente.TipoIncidente.Equals(TipoIncidente.GOL));
        
        /// <summary>
        /// Retorna el total de incidencias, de un determinado tipo en un partido.
        /// </summary>
        public static List<Incidente> TotalIncidenciasPartido(Partido partido, TipoIncidente tipoIncidente = TipoIncidente.GOL)
        {
            List<Incidente> retVal = new List<Incidente>();
            //Recorro el listado de incidencias del partido
            foreach (Incidente incidente in Administradora.Instance.Incidentes)
            {
                //Valido que el incidente coincida con el recibido por parámetro.
                if (incidente.TipoIncidente.Equals(tipoIncidente)) retVal.Add(incidente); //Si lo es, agrego la incidencia
            }
            return retVal;
        }
        /// <summary>
        /// Retorna el listado de incidencias sobre un jugador ocurridas en un partido determinado.
        /// </summary>
        public List<Incidente> GetIncidentes(Partido partido, Jugador jugador)
        {
            List<Incidente> jugadorPartidoIncidentes = new List<Incidente>();
            List<Incidente> partidoIncidentes = GetIncidentes(partido);

            foreach (Incidente incidente in partidoIncidentes)
            {
                if (incidente.Jugador.Equals(jugador)) jugadorPartidoIncidentes.Add(incidente);
            }
            return jugadorPartidoIncidentes;
        }
        /// <summary>
        /// Retorna el listado de incidencias ocurridas en un partido determinado.
        /// </summary>
        public static List<Incidente> GetIncidentes(Partido partido)
        {
            List<Incidente> partidoIncidentes = new List<Incidente>();

            foreach (Incidente incidente in Administradora.Instance.Incidentes)
            {
                if (incidente.Partido.Equals(partido)) partidoIncidentes.Add(incidente);
            }
            return partidoIncidentes;
        }
        
        public override string ToString() => $"Jugador {this.Jugador.Nombre} {this.TipoIncidente.ToString()}" + (this.Minuto > -1 ? $" - Minuto {this.Minuto}'" : "");

        /// <summary>
        /// Retorna TRUE si la incidencia del objeto es valida según las condiciones planteadas.<para/>
        /// 1 - Amonestaciones: no acumular más de dos sobre un mismo jugador.<para/>
        /// 2 - Expulsiones: no acumular más de una sobre un mismo jugador.
        /// </summary>
        public bool Validar()
        {
            bool retVal = true;
            int amonestacion = 0, expulsion = 0;
            //Traigo los Incidentes ya filtrados por Partido y Jugador.
            List<Incidente> jugadorPartidoIncidentes = GetIncidentes(this.Partido, this.Jugador);

            foreach (Incidente incidente in jugadorPartidoIncidentes)
            {
                //Si ya hay suficientes incidentes salgo del bucle.
                if (expulsion == 1 || amonestacion == 2) break;
                if (Incidente.EsTarjetaAmarilla(incidente)) amonestacion++;
                else if (Incidente.EsTarjetaRoja(incidente)) expulsion++;
            }
            if (expulsion == 1) retVal = false;
            else if (amonestacion == 2) retVal = false;

            return retVal;
        }

        //Getters && Setters
        public int Id { get { return this.id; } }
        public TipoIncidente TipoIncidente { get { return this.tipoIncidente; } set { this.tipoIncidente = value; } }
        public int Minuto { get { return this.minuto; } set { this.minuto = value; } }
        public Partido Partido { get { return this.partido; } set { this.partido = value; } }
        public Jugador Jugador { get { return this.jugador; } set { this.jugador = value; } }
    }
}

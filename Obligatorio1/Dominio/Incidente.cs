using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Incidente
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
        /// <summary>
        /// Genera el alta de la incidencia en el sistema.
        /// </summary>
        public static bool AltaIncidente(Incidente incidente)
        {
            bool retVal = false;
            
            if (Partido.EsPartidoValido(incidente.Partido))
            {
                retVal = incidente.ValidarIncidente();
                Administradora.Instance.Incidentes.Add(incidente);
            }

            return retVal;
        }
        /// <summary>
        /// Retorna TRUE si la incidencia del objeto es valida según las condiciones planteadas.<para/>
        /// 1 - Amonestaciones: no acumular más de dos sobre un mismo jugador.<para/>
        /// 2 - Expulsiones: no acumular más de una sobre un mismo jugador.
        /// </summary>
        private bool ValidarIncidente()
        {
            bool retVal = true;
            int amonestacion = 0, expulsion = 0;
            //Traigo los Incidentes ya filtrados por Partido y Jugador.
            List<Incidente> jugadorPartidoIncidentes = Administradora.Instance.GetIncidentes(this.Partido, this.Jugador);

            foreach (Incidente incidente in jugadorPartidoIncidentes)
            {
                //Si ya hay suficientes incidentes salgo del bucle
                if (expulsion == 1 && amonestacion == 2) break;

                if (Incidente.EsTarjetaAmarilla(incidente)) amonestacion++;
                if (Incidente.EsTarjetaRoja(incidente)) expulsion++;
            }

            if (expulsion == 1) retVal = false;
            else if (amonestacion == 2) retVal = false;

            return retVal;
        }
        public static bool EsTarjetaRoja(Incidente incidente)
        {
            return (incidente.TipoIncidente.Equals(TipoIncidente.TARJETA_ROJA));
        }
        public static bool EsTarjetaAmarilla(Incidente incidente)
        {
            return (incidente.TipoIncidente.Equals(TipoIncidente.TARJETA_AMARILLA));
        }
        public static bool EsGol(Incidente incidente)
        {
            return (incidente.TipoIncidente.Equals(TipoIncidente.GOL));
        }
        /// <summary>
        /// Retorna el total de incidencias, de un determinado tipo en un partido.
        /// </summary>
        public List<Incidente> TotalIncidenciasPartido(Partido partido, TipoIncidente tipoIncidente = TipoIncidente.GOL)
        {
            List<Incidente> retVal = new List<Incidente>();
            //Recorro el listado de incidencias del partido
            foreach (Incidente incidente in Administradora.Instance.Incidentes)
            {
                //Valido que el incidente coincida con el recibido por parámetro.
                if (incidente.TipoIncidente.Equals(tipoIncidente))
                {
                    //Si lo es, valido que tenga incidencias de gol


                }
            }
            return retVal;
        }
        //Getters && Setters
        public int Id {
            get {return this.id;} 
        }
        public TipoIncidente TipoIncidente
        {
            get { return this.tipoIncidente; }
        }
        public int Minuto
        {
            get { return this.minuto; }
        }
        public Partido Partido
        {
            get { return this.partido; }
        }
        public Jugador Jugador
        {
            get { return this.jugador; }
        }
    }
}

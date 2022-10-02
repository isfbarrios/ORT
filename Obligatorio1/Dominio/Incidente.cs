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
                //Guardo el incidente en la lista genérica y a su vez, en la lista específica de ese partido.
                incidente.Partido.Incidentes.Add(incidente);
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
            List<Incidente> jugadorPartidoIncidentes = GetIncidentes(this.Partido, this.Jugador);

            foreach (Incidente incidente in jugadorPartidoIncidentes)
            {
                //Si ya hay suficientes incidentes salgo del bucle.
                if (expulsion == 1 && amonestacion == 2) break;

                if (Incidente.EsTarjetaAmarilla(incidente)) amonestacion++;
                if (Incidente.EsTarjetaRoja(incidente)) expulsion++;
            }

            if (expulsion == 1) retVal = false;
            else if (amonestacion == 2) retVal = false;

            return retVal;
        }
        /// <summary>
        /// Retorna TRUE si el incidente corresponde a una expulsión.
        /// </summary>
        public static bool EsTarjetaRoja(Incidente incidente) => (incidente.TipoIncidente.Equals(TipoIncidente.TARJETA_ROJA));
        /// <summary>
        /// Retorna TRUE si el incidente corresponde a una amonestación.
        /// </summary>
        public static bool EsTarjetaAmarilla(Incidente incidente) => (incidente.TipoIncidente.Equals(TipoIncidente.TARJETA_AMARILLA));
        /// <summary>
        /// Retorna TRUE si el incidente corresponde a un gol.
        /// </summary>
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
                if (incidente.TipoIncidente.Equals(tipoIncidente))
                {
                    //Si lo es, agrego la incidencia
                    retVal.Add(incidente);
                }
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
        public List<Incidente> GetIncidentes(Partido partido)
        {
            List<Incidente> partidoIncidentes = new List<Incidente>();

            foreach (Incidente incidente in Administradora.Instance.Incidentes)
            {
                if (incidente.Partido.Equals(partido)) partidoIncidentes.Add(incidente);
            }
            return partidoIncidentes;
        }
        /// <summary>
        /// Retorna el objecto en formato string.
        /// </summary>
        public override string ToString() => $"Jugador {this.Jugador.Nombre} {this.TipoIncidente.ToString()}" + (this.Minuto > -1 ? $" - Minuto {this.Minuto}'" : "");
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
        public static void PreLoadIncidentes()
        {
            //Catar (Local) vs Alemania (Visitante)
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[0], Administradora.Instance.Jugadores[59], TipoIncidente.TARJETA_AMARILLA, 7));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[0], Administradora.Instance.Jugadores[79], TipoIncidente.TARJETA_AMARILLA, 22));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[0], Administradora.Instance.Jugadores[78], TipoIncidente.GOL, 26));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[0], Administradora.Instance.Jugadores[32], TipoIncidente.GOL, 44));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[0], Administradora.Instance.Jugadores[36], TipoIncidente.GOL, 87));
            //Catar (Local) vs Dinamarca (Visitante)
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[31], TipoIncidente.TARJETA_AMARILLA, 41));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[158], TipoIncidente.TARJETA_ROJA, 63));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[159], TipoIncidente.TARJETA_ROJA, 77));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[161], TipoIncidente.TARJETA_AMARILLA, 79));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[88], TipoIncidente.GOL, 80));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[32], TipoIncidente.GOL, 81));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[33], TipoIncidente.GOL, 85));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[32], TipoIncidente.GOL, 87));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[32], TipoIncidente.GOL, 88));
            //Catar (Local) vs Brasil (Visitante)
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[2], Administradora.Instance.Jugadores[126], TipoIncidente.TARJETA_AMARILLA, 15));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[2], Administradora.Instance.Jugadores[124], TipoIncidente.GOL, 76));
            //Alemania (Local) vs Dinamarca (Visitante)
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[3], Administradora.Instance.Jugadores[101], TipoIncidente.TARJETA_AMARILLA, 55));
            //Alemania (Local) vs Brasil (Visitante)
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[4], Administradora.Instance.Jugadores[124], TipoIncidente.GOL, 12));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[4], Administradora.Instance.Jugadores[124], TipoIncidente.GOL, 16));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[4], Administradora.Instance.Jugadores[124], TipoIncidente.GOL, 33));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[4], Administradora.Instance.Jugadores[124], TipoIncidente.GOL, 61));
            //Dinamarca (Local) vs Brasil (Visitante)
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[5], Administradora.Instance.Jugadores[88], TipoIncidente.TARJETA_AMARILLA, 2));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[5], Administradora.Instance.Jugadores[126], TipoIncidente.GOL, 44));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[5], Administradora.Instance.Jugadores[124], TipoIncidente.GOL, 63));
            //Francia (Local) vs Bélgica (Visitante)
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[6], Administradora.Instance.Jugadores[132], TipoIncidente.TARJETA_AMARILLA, 12));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[6], Administradora.Instance.Jugadores[133], TipoIncidente.TARJETA_AMARILLA, 17));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[6], Administradora.Instance.Jugadores[151], TipoIncidente.GOL, 33));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[6], Administradora.Instance.Jugadores[154], TipoIncidente.GOL, 43));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[6], Administradora.Instance.Jugadores[154], TipoIncidente.GOL, 59));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[6], Administradora.Instance.Jugadores[160], TipoIncidente.GOL, 88));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[6], Administradora.Instance.Jugadores[160], TipoIncidente.TARJETA_ROJA, 89));
            //Francia (Local) vs Croacia (Visitante)
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[7], Administradora.Instance.Jugadores[154], TipoIncidente.GOL, 11));
            //Francia (Local) vs España (Visitante)
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[8], Administradora.Instance.Jugadores[215], TipoIncidente.GOL, 1));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[8], Administradora.Instance.Jugadores[224], TipoIncidente.GOL, 74));
            //Bélgica (Local) vs Croacia (Visitante)
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[9], Administradora.Instance.Jugadores[157], TipoIncidente.TARJETA_AMARILLA, 37));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[9], Administradora.Instance.Jugadores[159], TipoIncidente.GOL, 41));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[9], Administradora.Instance.Jugadores[190], TipoIncidente.GOL, 44));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[9], Administradora.Instance.Jugadores[190], TipoIncidente.GOL, 63));
            //Bélgica (Local) vs España (Visitante)
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[10], Administradora.Instance.Jugadores[224], TipoIncidente.GOL, 79));
            //Croacia (Local) vs España (Visitante)
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[11], Administradora.Instance.Jugadores[182], TipoIncidente.TARJETA_AMARILLA, 12));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[11], Administradora.Instance.Jugadores[190], TipoIncidente.GOL, 53));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[11], Administradora.Instance.Jugadores[190], TipoIncidente.GOL, 77));
            //Octavos
            //Croacia (Local) vs España (Visitante)
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[48], Administradora.Instance.Jugadores[190], TipoIncidente.GOL, 86));
            //Francia (Local) vs Brasil (Visitante)
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[49], Administradora.Instance.Jugadores[124], TipoIncidente.GOL, 17));
            AltaIncidente(new Incidente(Administradora.Instance.Partidos[49], Administradora.Instance.Jugadores[124], TipoIncidente.TARJETA_AMARILLA, 34));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Partido
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
        private Etapa etapa;

        //Constructores
        public Partido() 
        {
            this.id = ++autoIncrementId;
        }

        public Partido(Seleccion local, Seleccion visitante, DateTime fecha, Etapa etapa)
        {
            this.id = ++autoIncrementId;
            this.local = local;
            this.visitante = visitante;
            this.fecha = fecha;
            this.finalizado = false; //Por defecto, no finalizado
            this.resultado = Resultado.PENDIENTE;
            this.etapa = etapa;
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
            Partido retPartido = new Partido();
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
                List<Jugador> jugadores = Jugador.TotalJugadoresPartidos(partido);

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
            List<Jugador> jugadores = Jugador.TotalJugadoresPartidos(partido);
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
        public override string ToString() => ($"Fecha {this.Fecha} - {this.Local.Pais.Nombre} (Local) vs {this.Visitante.Pais.Nombre} (Visitante) - {this.Etapa.ToString()}.");
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
        public Etapa Etapa
        {
            get { return this.etapa; }
        }
    }
    public static void PrecargaPartidos()
    {
        //Partidos fase de grupos
        //Grupo A
        Partido.AltaPartido(new Partido(Administradora.Instance.Selecciones[0], Administradora.Instance.Selecciones[1], DateTime.Parse("2022-11-22"), Etapa.FASE_GRUPOS));
        Partido.AltaPartido(new Partido(Administradora.Instance.Selecciones[2], Administradora.Instance.Selecciones[3], DateTime.Parse("2022-11-23"), Etapa.FASE_GRUPOS));
        //Grupo B
        Partido.AltaPartido(new Partido(Administradora.Instance.Selecciones[4], Administradora.Instance.Selecciones[5], DateTime.Parse("2022-11-24"), Etapa.FASE_GRUPOS));
        Partido.AltaPartido(new Partido(Administradora.Instance.Selecciones[6], Administradora.Instance.Selecciones[7], DateTime.Parse("2022-11-25"), Etapa.FASE_GRUPOS));
        //Grupo C
        Partido.AltaPartido(new Partido(Administradora.Instance.Selecciones[8], Administradora.Instance.Selecciones[9], DateTime.Parse("2022-11-26"), Etapa.FASE_GRUPOS));
        Partido.AltaPartido(new Partido(Administradora.Instance.Selecciones[10], Administradora.Instance.Selecciones[11], DateTime.Parse("2022-11-27"), Etapa.FASE_GRUPOS));
        //Grupo D
        Partido.AltaPartido(new Partido(Administradora.Instance.Selecciones[12], Administradora.Instance.Selecciones[13], DateTime.Parse("2022-11-28"), Etapa.FASE_GRUPOS));
        Partido.AltaPartido(new Partido(Administradora.Instance.Selecciones[14], Administradora.Instance.Selecciones[15], DateTime.Parse("2022-11-29"), Etapa.FASE_GRUPOS));
        //Grupo E
        Partido.AltaPartido(new Partido(Administradora.Instance.Selecciones[16], Administradora.Instance.Selecciones[17], DateTime.Parse("2022-11-30"), Etapa.FASE_GRUPOS));
        Partido.AltaPartido(new Partido(Administradora.Instance.Selecciones[18], Administradora.Instance.Selecciones[19], DateTime.Parse("2022-12-01"), Etapa.FASE_GRUPOS));
        //Grupo F
        Partido.AltaPartido(new Partido(Administradora.Instance.Selecciones[20], Administradora.Instance.Selecciones[21], DateTime.Parse("2022-12-02"), Etapa.FASE_GRUPOS));
        Partido.AltaPartido(new Partido(Administradora.Instance.Selecciones[22], Administradora.Instance.Selecciones[23], DateTime.Parse("2022-12-03"), Etapa.FASE_GRUPOS));

        //Partidos eliminatorias
        Partido.AltaPartido(new Partido(Administradora.Instance.Selecciones[22], Administradora.Instance.Selecciones[23], DateTime.Parse("2022-12-03"), Etapa.FASE_GRUPOS));
    }
}

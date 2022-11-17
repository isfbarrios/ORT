using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public abstract class Partido : IValidar
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
        /// Retorna el objeto correspondiente al id especificado.
        /// </summary>
        public static Partido GetPartido(int id)
        {
            Partido retVal = null;
            foreach (Partido p in Administradora.Instance.Partidos)
            {
                if (p.Id == id) retVal = p;
            }
            return retVal;
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
                //Si lo es, valido que tenga incidencias de gol y acumulo el resultado.
                if (seleccion.JugadorDeSeleccion(jugador)) retVal += Incidente.TotalIncidenciasPartido(partido).Count;
            }
            return retVal;
        }
        private bool ValidarFechaDePartido()
        {
            bool retVal = false;
            DateTime dateFrom = Convert.ToDateTime("20/11/2022");
            DateTime dateTo = Convert.ToDateTime("18/12/2022");
            if (this.Fecha >= dateFrom && this.Fecha <= dateTo)  retVal = true;
            return retVal;
        }
        /// <summary>
        /// Retorna el objecto en formato string.
        /// </summary>
        public abstract override string ToString();
        /// <summary>
        /// Dispara el evento de finalizaci'on de un partido.
        /// </summary>
        public abstract bool FinalizarPartido();
        /// <summary>
        /// Retorna el listado de incidencias tipo Gol ocurridas en un partido determinado.
        /// </summary>
        public List<Incidente> GetIncidentesDeGol()
        {
            List<Incidente> retVal = new List<Incidente>();
            //Traigo todos los incidentes de este partido.
            foreach (Incidente i in this.Incidentes)
            {
                if (Incidente.EsGol(i)) retVal.Add(i);
            }
            return retVal;
        }
        /// <summary>
        /// Recorre las incidencias de Gol de un partido.
        /// Retorna un valor númerico dependiendo si el ganador fue el equipo local (-1), empate (0) o si el ganador fue el equipo visitante (1).
        /// </summary>
        public abstract int CalcularResultado();
        /// <summary>
        /// Retorna el resultado del partido.
        /// </summary>
        public abstract string ExpresarResultado();
        /// <summary>
        /// Retorna el objecto en formato string.
        /// </summary>
        public string TituloToString() => this.Local.Pais.Nombre + " vs " + this.Visitante.Pais.Nombre;
        /// <summary>
        /// Retorna TRUE si el partido cumple con la condicion de tener Selecciones validas para Local y Visitante.
        /// </summary>
        public bool Validar() => (this.Local.Validar() && this.Visitante.Validar());
        //Getters & Setters
        public int Id { get { return this.id; } }
        public Seleccion Local { get { return this.local; } set { this.local = value; } }
        public Seleccion Visitante { get { return this.visitante; } set { this.visitante = value; } }
        public DateTime Fecha { get { return this.fecha; } set { this.fecha = value; } }
        public bool Finalizado { get { return this.finalizado; } set { this.finalizado = value; } }
        public Resultado Resultado { get { return this.resultado; } set { this.resultado = value; } }
        public List<Incidente> Incidentes { get { return this.incidentes; } }
    }
}

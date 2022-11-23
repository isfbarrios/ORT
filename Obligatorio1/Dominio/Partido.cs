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

        public static Partido GetPartido(int id)
        {
            Partido retVal = null;
            foreach (Partido p in Administradora.Instance.Partidos)
            {
                if (p.Id == id) retVal = p;
            }
            return retVal;
        }

        public List<Partido> GetPartidos(Jugador jugador)
        {
            List<Partido> retVal = new List<Partido>();

            foreach (Partido partido in Administradora.Instance.Partidos)
            {
                List<Jugador> jugadores = Jugador.TotalJugadoresPartido(partido);

                foreach (Jugador jPartido in jugadores)
                {
                    if (jPartido.Equals(jugador)) retVal.Add(partido);
                }
            }
            return retVal;
        }

        public static List<Partido> GetPartidosFinalizados(string dateFrom, string dateTo)
        {
            List<Partido> retVal = new List<Partido>();

            foreach (Partido p in Administradora.Instance.Partidos)
            {
                int fr = DateTime.Compare(p.Fecha, DateTime.Parse(dateFrom));
                int to = DateTime.Compare(p.Fecha, DateTime.Parse(dateTo));

                if (p.Finalizado && DateTime.Compare(p.Fecha, DateTime.Parse(dateFrom)) >= 0 
                    && DateTime.Compare(p.Fecha, DateTime.Parse(dateTo)) <= 0) retVal.Add(p);
            }
            return retVal;
        }

        public List<Incidente> TotalGolesPartido(Seleccion seleccion)
        {
            List<Incidente> retVal = new List<Incidente>();

            foreach (Incidente i in TotalIncidentesPartido(seleccion))
            {
                if (Incidente.EsGol(i)) retVal.Add(i);
            }

            return retVal;
        }
        public List<Incidente> TotalAmarillasPartido(Seleccion seleccion)
        {
            List<Incidente> retVal = new List<Incidente>();

            foreach (Incidente i in TotalIncidentesPartido(seleccion))
            {
                if (Incidente.EsTarjetaAmarilla(i)) retVal.Add(i);
            }

            return retVal;
        }
        public List<Incidente> TotalRojasPartido(Seleccion seleccion)
        {
            List<Incidente> retVal = new List<Incidente>();

            foreach (Incidente i in TotalIncidentesPartido(seleccion))
            {
                if (Incidente.EsTarjetaRoja(i)) retVal.Add(i);
            }

            return retVal;
        }
        public List<Incidente> TotalIncidentesPartido(Seleccion seleccion)
        {
            List<Incidente> retVal = new List<Incidente>();

            foreach (Incidente i in Administradora.Instance.Incidentes)
            {
                if (i.Partido.Equals(this) && seleccion.JugadorDeSeleccion(i.Jugador)) retVal.Add(i);
            }

            return retVal;
        }

        public bool TuvoAlargue()
        {
            bool retVal = false;
            foreach (Incidente i in this.Incidentes) {
                if (i.Minuto > 90) retVal = true;
            }
            return retVal;
        }
        public bool TuvoPenales()
        {
            bool retVal = false;
            foreach (Incidente i in this.Incidentes)
            {
                if (i.Minuto == -1) retVal = true;
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

        public abstract override string ToString();

        public abstract bool FinalizarPartido();

        public abstract string GetPartidoType();
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
        
        public abstract int CalcularResultado();
        
        public abstract string ExpresarResultado();

        public abstract string GetFase();
       
        public string TituloToString() => this.Local.Pais.Nombre + " vs " + this.Visitante.Pais.Nombre;

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

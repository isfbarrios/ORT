using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Administradora
    {
        private static Administradora instance;

        //Variables para simular la sesión del sistema
        public static string session_user = "";
        public static string session_pass = "";

        private List<Pais> paises = new List<Pais>();
        private List<Seleccion> selecciones = new List<Seleccion>();
        private List<Jugador> jugadores = new List<Jugador>();
        private List<Partido> partidos = new List<Partido>();
        private List<Incidente> incidentes = new List<Incidente>();
        private List<Periodista> periodistas = new List<Periodista>();
        private List<Resultado> resultados = new List<Resultado>();
        private List<Resena> resenas = new List<Resena>();

        private int minimoParaVIP = 0;

        private Administradora() 
        {
            
        }

        public static Administradora Instance
        {
            get
            {
                if (instance == null) instance = new Administradora();
                return instance;
            }
        }
        //Getters & Setters
        public List<Pais> Paises {
            get { return this.paises; } 
        }
        public List<Seleccion> Selecciones
        {
            get { return this.selecciones; }
        }
        public List<Jugador> Jugadores
        {
            get { return this.jugadores; }
        }
        public List<Partido> Partidos
        {
            get { return this.partidos; }
        }
        public List<Resultado> Resultados
        {
            get { return this.resultados; }
        }
        public List<Resena> Resenas
        {
            get { return this.resenas; }
        }
        public List<Periodista> Periodistas
        {
            get { return this.periodistas; }
        }
        public List<Incidente> Incidentes
        {
            get { return this.incidentes; }
        }
        public int MinimoParaVIP
        {
            get { return this.minimoParaVIP; }
            set { this.minimoParaVIP = value; }
        }
        
        //Métodos de precarga de datos
        public static void PreLoad()
        {
            try
            {
                //Alta de jugadores
                Pais.PreLoadPaises();
                Jugador.PreLoadJugadores();
                Seleccion.PrecargaSelecciones();
                Periodista.PreLoadPeriodistas();
                Partido.PreLoadPartidos();
                Incidente.PreLoadIncidentes();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}

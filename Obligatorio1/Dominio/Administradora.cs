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

        //private static Dictionary<string, List<Seleccion>> seleccionesPorGrupo = new Dictionary<string, List<Seleccion>>();
        //private static Dictionary<string, List<Partido>> partidosPorGrupo = new Dictionary<string, List<Partido>>();

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
        /*
        public Dictionary<string, List<Seleccion>> SeleccionesPorGrupo
        {
            get { return seleccionesPorGrupo; }
        }
        public Dictionary<string, List<Partido>> PartidoPorGrupo
        {
            get { return partidosPorGrupo; }
        }
        */
        //Métodos de precarga de datos
        public static void PreLoad()
        {
            try
            {
                //Alta de jugadores
                Pais.PreLoadPaises();
                Jugador.PreLoadJugadores();
                Seleccion.PrecargaSelecciones();
            }
            catch (OverflowException ov)
            {
                Console.WriteLine($"Error: {ov.Message}");
            }
        }
        public static void PrecargaPeriodistas()
        {
            Periodista.AltaPeriodista(new Periodista("Fabricio", "Barrios", "fb292342@fi365.ort.edu.uy", "nosoyreal1234"));
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
}

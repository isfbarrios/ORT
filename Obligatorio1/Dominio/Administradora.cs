using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Administradora
    {
        private static Administradora instance;

        private List<Pais> paises = new List<Pais>();
        private List<Seleccion> selecciones = new List<Seleccion>();
        private List<Jugador> jugadores = new List<Jugador>();
        private List<Partido> partidos = new List<Partido>();
        private List<Incidente> incidentes = new List<Incidente>();
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Resultado> resultados = new List<Resultado>();
        private List<Resena> resenas = new List<Resena>();
        private int minimoParaVIP = 0;

        //Variables para controlar que este la precarga hecha
        private bool loaded = false;

        //Variables de utilidad
        private static DateTime iniDate = new DateTime(2022, 11, 20);
        private static DateTime endDate = new DateTime(2022, 12, 18);
        private static Random gen;

        private Administradora() { }

        public static Administradora Instance
        {
            get
            {
                if (instance == null) instance = new Administradora();
                return instance;
            }
        }
        //Funcionalidades

        public static Usuario GetUsuario(String nombre)
        {
            Usuario retVal = null;
            foreach (Usuario u in Administradora.Instance.Usuarios)
            {
                if (u.Nombre == nombre) retVal = u;
            }
            return retVal;
        }

        /// <summary>
        /// Valida que un String sea igual o mayor al segundo parámetro.
        /// </summary>
        public static bool ValidLength(string a, int b) => a.Length >= b ? true : false;
        /// <summary>
        /// Retorna TRUE si un mail es valido.
        /// </summary>
        public static bool ValidMail(String a) => (a.Length > 0 && a.IndexOf("@") > 0 && !a.StartsWith("@") && !a.EndsWith("@"));
        /// <summary>
        /// Retorna una fecha aleatoria entre un rango de fechas predefinido.
        /// </summary>
        private static DateTime RandomDate()
        {
            gen = new Random();
            return iniDate.AddDays(new Random().Next(29)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
        }

        //Getters & Setters
        public List<Pais> Paises { get { return this.paises; } }
        public List<Seleccion> Selecciones { get { return this.selecciones; } }
        public List<Jugador> Jugadores { get { return this.jugadores; } }
        public List<Partido> Partidos { get { return this.partidos; } }
        public List<Resultado> Resultados { get { return this.resultados; } }
        public List<Resena> Resenas { get { return this.resenas; } }
        public List<Usuario> Usuarios { get { return this.usuarios; } }
        public List<Incidente> Incidentes { get { return this.incidentes; } }
        public int MinimoParaVIP { get { return this.minimoParaVIP; } set { this.minimoParaVIP = value; } }
        public bool Loaded { get { return this.loaded; } set { this.loaded = value; } }

        //Métodos de precarga de datos
        public static void PreLoad()
        {
            try
            {
                Instance.Loaded = true;
                //Alta de jugadores
                PreLoadPaises();
                PreLoadJugadores();
                PrecargaSelecciones();
                PreLoadPeriodistas();
                PreLoadPartidos();
                PreLoadIncidentes();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        public static void PreLoadJugadores()
        {
            //Alta jugadores
            Jugador.AltaJugador(new Jugador("23", "Emiliano Martínez", DateTime.Parse("1992-09-02"), 195, Pie.DERECHO, 28000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("12", "Gerónimo Rulli", DateTime.Parse("1992-05-20"), 189, Pie.DERECHO, 6000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Franco Armani", DateTime.Parse("1986-10-16"), 189, Pie.DERECHO, 3500000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("13", "Cristian Romero", DateTime.Parse("1998-04-27"), 185, Pie.DERECHO, 48000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("16", "Lisandro Martínez", DateTime.Parse("1998-01-18"), 175, Pie.IZQUIERDO, 32000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("25", "Marcos Senesi", DateTime.Parse("1997-05-10"), 185, Pie.IZQUIERDO, 17000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("114", "Lucas Martínez Quarta", DateTime.Parse("1996-05-10"), 183, Pie.DERECHO, 12000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("6", "Germán Pezzella", DateTime.Parse("1991-06-27"), 187, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("19", "Nicolás Otamendi", DateTime.Parse("1988-02-12"), 183, Pie.DERECHO, 3500000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("8", "Marcos Acuña", DateTime.Parse("1991-10-28"), 172, Pie.IZQUIERDO, 18000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("3", "Nicolás Tagliafico", DateTime.Parse("1992-08-31"), 172, Pie.IZQUIERDO, 11000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("2", "Juan Foyth", DateTime.Parse("1998-01-12"), 187, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("26", "Nahuel Molina", DateTime.Parse("1998-04-06"), 175, Pie.DERECHO, 20000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("4", "Gonzalo Montiel", DateTime.Parse("1997-01-01"), 176, Pie.DERECHO, 14000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("18", "Guido Rodríguez", DateTime.Parse("1994-04-12"), 185, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Leandro Paredes", DateTime.Parse("1994-06-29"), 18, Pie.DERECHO, 17000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("7", "Rodrigo de Paul", DateTime.Parse("1994-05-24"), 18, Pie.DERECHO, 40000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("20", "Giovani Lo Celso", DateTime.Parse("1996-04-09"), 177, Pie.IZQUIERDO, 22000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("14", "Exequiel Palacios", DateTime.Parse("1998-10-05"), 177, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("5", "Alexis Mac Allister", DateTime.Parse("1998-12-24"), 174, Pie.DERECHO, 16000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("17", "Papu Gómez", DateTime.Parse("1988-02-15"), 167, Pie.DERECHO, 6000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("15", "Nicolás González", DateTime.Parse("1998-04-06"), 18, Pie.IZQUIERDO, 25000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("10", "Lionel Messi", DateTime.Parse("1987-06-24"), 17, Pie.IZQUIERDO, 50000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("11", "Ángel Di María", DateTime.Parse("1988-02-14"), 18, Pie.IZQUIERDO, 12000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("21", "Paulo Dybala", DateTime.Parse("1993-11-15"), 177, Pie.IZQUIERDO, 35000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.MEDIAPUNTA));
            Jugador.AltaJugador(new Jugador("19", "Joaquín Correa", DateTime.Parse("1994-08-13"), 188, Pie.DERECHO, 23000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.MEDIAPUNTA));
            Jugador.AltaJugador(new Jugador("22", "Lautaro Martínez", DateTime.Parse("1997-08-22"), 174, Pie.DERECHO, 75000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("9", "Julián Álvarez", DateTime.Parse("2000-01-31"), 17, Pie.DERECHO, 23000000, Moneda.EUROS, Pais.GetPais("Argentina"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("22", "Meshaal Barsham", DateTime.Parse("1998-02-14"), 18, Pie.DERECHO, 450000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Saad Al-Sheeb", DateTime.Parse("1990-02-19"), 184, Pie.DERECHO, 200000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("21", "Yousef Hassan", DateTime.Parse("1996-05-24"), 0, Pie.NO_DEFINIDO, 150000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("5", "Tarek Salman", DateTime.Parse("1997-12-05"), 179, Pie.DERECHO, 550000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("2", "Pedro Miguel", DateTime.Parse("1990-08-06"), 182, Pie.DERECHO, 500000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("15", "Bassam Al-Rawi", DateTime.Parse("1997-12-16"), 175, Pie.DERECHO, 500000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("16", "Boualem Khoukhi", DateTime.Parse("1990-07-09"), 18, Pie.DERECHO, 500000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("3", "Abdelkarim Hassan", DateTime.Parse("1993-08-28"), 186, Pie.IZQUIERDO, 775000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("14", "Homam Ahmed", DateTime.Parse("1999-08-25"), 186, Pie.IZQUIERDO, 500000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("13", "Musab Khoder", DateTime.Parse("1993-01-01"), 174, Pie.DERECHO, 325000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("12", "Karim Boudiaf", DateTime.Parse("1990-09-16"), 187, Pie.DERECHO, 450000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("23", "Assim Madibo", DateTime.Parse("1996-10-22"), 168, Pie.DERECHO, 300000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("115", "Salem Al-Hajri", DateTime.Parse("1996-04-10"), 183, Pie.DERECHO, 250000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("167", "Ahmed Fadel", DateTime.Parse("1993-04-07"), 0, Pie.NO_DEFINIDO, 175000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("154", "Abdulaziz Hatem", DateTime.Parse("1990-10-28"), 183, Pie.IZQUIERDO, 500000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("4", "Mohammed Waad", DateTime.Parse("1999-09-18"), 183, Pie.IZQUIERDO, 300000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("20", "Abdullah Al-Ahrak", DateTime.Parse("1997-05-10"), 175, Pie.DERECHO, 500000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("8", "Ali Asad", DateTime.Parse("1993-01-19"), 175, Pie.DERECHO, 250000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("11", "Akram Afif", DateTime.Parse("1996-11-18"), 177, Pie.DERECHO, 5500000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Abdelrahman Moustafa", DateTime.Parse("1997-04-05"), 168, Pie.DERECHO, 375000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("18", "Khalid Muneer Mazeed", DateTime.Parse("1998-02-24"), 174, Pie.NO_DEFINIDO, 350000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("41", "Hasan Al-Haydos", DateTime.Parse("1990-12-11"), 174, Pie.DERECHO, 1300000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Hazem Ahmed", DateTime.Parse("1998-02-02"), 0, Pie.IZQUIERDO, 400000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("17", "Ismaeel Mohammed", DateTime.Parse("1990-04-05"), 168, Pie.DERECHO, 250000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("19", "Almoez Ali", DateTime.Parse("1996-08-19"), 18, Pie.DERECHO, 2800000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("7", "Ahmed Alaaeldin", DateTime.Parse("1993-01-31"), 177, Pie.DERECHO, 700000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Mohammed Muntari", DateTime.Parse("1993-12-20"), 194, Pie.DERECHO, 350000, Moneda.EUROS, Pais.GetPais("Catar"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("1", "Manuel Neuer", DateTime.Parse("1986-03-27"), 193, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("12", "Kevin Trapp", DateTime.Parse("1990-07-08"), 189, Pie.DERECHO, 7000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("22", "Oliver Baumann", DateTime.Parse("1990-06-02"), 187, Pie.DERECHO, 4500000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("2", "Antonio Rüdiger", DateTime.Parse("1993-03-03"), 19, Pie.DERECHO, 40000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("15", "Niklas Süle", DateTime.Parse("1995-09-03"), 195, Pie.DERECHO, 35000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("23", "Nico Schlotterbeck", DateTime.Parse("1999-12-01"), 191, Pie.IZQUIERDO, 33000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Jonathan Tah", DateTime.Parse("1996-02-11"), 195, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("5", "Thilo Kehrer", DateTime.Parse("1996-09-21"), 186, Pie.DERECHO, 22000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("16", "Lukas Klostermann", DateTime.Parse("1996-06-03"), 189, Pie.DERECHO, 18000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("3", "David Raum", DateTime.Parse("1998-04-22"), 18, Pie.IZQUIERDO, 20000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("17", "Benjamin Henrichs", DateTime.Parse("1997-02-23"), 185, Pie.DERECHO, 14000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("6", "Joshua Kimmich", DateTime.Parse("1995-02-08"), 177, Pie.DERECHO, 80000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("2", "Anton Stach", DateTime.Parse("1998-11-15"), 194, Pie.AMBIDIESTRO, 13000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("8", "Leon Goretzka ", DateTime.Parse("1995-02-06"), 189, Pie.DERECHO, 65000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("21", "Ilkay Gündogan", DateTime.Parse("1990-10-24"), 18, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("7", "Kai Havertz", DateTime.Parse("1999-06-11"), 19, Pie.IZQUIERDO, 70000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("14", "Jamal Musiala", DateTime.Parse("2003-02-26"), 183, Pie.DERECHO, 65000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("20", "Julian Brandt", DateTime.Parse("1996-05-02"), 185, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("18", "Jonas Hofmann", DateTime.Parse("1992-07-14"), 176, Pie.DERECHO, 13000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("19", "Leroy Sané", DateTime.Parse("1996-01-11"), 183, Pie.IZQUIERDO, 60000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("10", "Serge Gnabry", DateTime.Parse("1995-07-14"), 176, Pie.DERECHO, 65000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("13", "Thomas Müller", DateTime.Parse("1989-09-13"), 185, Pie.DERECHO, 22000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.MEDIAPUNTA));
            Jugador.AltaJugador(new Jugador("9", "Timo Werner", DateTime.Parse("1996-03-06"), 18, Pie.DERECHO, 35000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("10", "Karim Adeyemi", DateTime.Parse("2002-01-18"), 18, Pie.IZQUIERDO, 35000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("11", "Lukas Nmecha", DateTime.Parse("1998-12-14"), 185, Pie.DERECHO, 18000000, Moneda.EUROS, Pais.GetPais("Alemania"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("1", "Kasper Schmeichel", DateTime.Parse("1986-11-05"), 189, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("16", "Daniel Iversen", DateTime.Parse("1997-07-19"), 191, Pie.NO_DEFINIDO, 2000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("22", "Peter Vindahl", DateTime.Parse("1998-02-16"), 195, Pie.DERECHO, 900000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("6", "Andreas Christensen", DateTime.Parse("1996-04-10"), 187, Pie.DERECHO, 35000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("2", "Joachim Andersen", DateTime.Parse("1996-05-31"), 192, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("3", "Jannik Vestergaard", DateTime.Parse("1992-08-03"), 199, Pie.AMBIDIESTRO, 13000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Victor Nelsson", DateTime.Parse("1998-10-14"), 185, Pie.DERECHO, 12000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("20", "Nicolai Boilesen", DateTime.Parse("1992-02-16"), 186, Pie.IZQUIERDO, 1000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("13", "Rasmus Kristensen", DateTime.Parse("1997-07-11"), 187, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("5", "Joakim Maehle", DateTime.Parse("1997-05-20"), 185, Pie.DERECHO, 14000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("17", "Jens Stryger Larsen", DateTime.Parse("1991-02-21"), 18, Pie.AMBIDIESTRO, 2000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("8", "Morten Hjulmand", DateTime.Parse("1999-06-25"), 185, Pie.DERECHO, 6500000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("23", "Pierre-Emile Höjbjerg", DateTime.Parse("1995-08-05"), 185, Pie.DERECHO, 40000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("15", "Philip Billing", DateTime.Parse("1996-06-11"), 193, Pie.IZQUIERDO, 18000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("7", "Mathias Jensen", DateTime.Parse("1996-01-01"), 18, Pie.DERECHO, 10000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("18", "Daniel Wass", DateTime.Parse("1989-05-31"), 178, Pie.DERECHO, 6000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("11", "Andreas Skov Olsen", DateTime.Parse("1999-12-29"), 187, Pie.IZQUIERDO, 12000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.INTERIOR_DERECHO));
            Jugador.AltaJugador(new Jugador("10", "Christian Eriksen", DateTime.Parse("1992-02-14"), 182, Pie.DERECHO, 20000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("14", "Mikkel Damsgaard", DateTime.Parse("2000-07-03"), 18, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("12", "Robert Skov", DateTime.Parse("1996-05-20"), 185, Pie.IZQUIERDO, 7000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("19", "Jonas Wind", DateTime.Parse("1999-02-07"), 19, Pie.DERECHO, 14000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("21", "Andreas Cornelius", DateTime.Parse("1993-03-16"), 193, Pie.IZQUIERDO, 9000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("9", "Martin Braithwaite", DateTime.Parse("1991-06-05"), 177, Pie.DERECHO, 6000000, Moneda.EUROS, Pais.GetPais("Dinamarca"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("1", "Alisson", DateTime.Parse("1992-10-02"), 191, Pie.DERECHO, 50000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("23", "Ederson", DateTime.Parse("1993-08-17"), 188, Pie.IZQUIERDO, 45000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("12", "Weverton", DateTime.Parse("1987-12-13"), 189, Pie.DERECHO, 4500000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("4", "Marquinhos", DateTime.Parse("1994-05-14"), 183, Pie.DERECHO, 70000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("2", "Éder Militão", DateTime.Parse("1998-01-18"), 186, Pie.DERECHO, 60000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("22", "Gabriel Magalhães", DateTime.Parse("1997-12-19"), 19, Pie.IZQUIERDO, 38000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Léo Ortiz", DateTime.Parse("1996-01-03"), 185, Pie.DERECHO, 7500000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("3", "Thiago Silva", DateTime.Parse("1984-09-22"), 181, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("16", "Alex Telles", DateTime.Parse("1992-12-15"), 181, Pie.IZQUIERDO, 18000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("14", "Guilherme Arana", DateTime.Parse("1997-04-14"), 176, Pie.IZQUIERDO, 14000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("6", "Alex Sandro", DateTime.Parse("1991-01-26"), 181, Pie.IZQUIERDO, 6000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("2", "Danilo", DateTime.Parse("1991-07-15"), 184, Pie.DERECHO, 13000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("13", "Dani Alves", DateTime.Parse("1983-05-06"), 172, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("15", "Fabinho", DateTime.Parse("1993-10-23"), 188, Pie.DERECHO, 60000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("5", "Casemiro", DateTime.Parse("1992-02-23"), 185, Pie.DERECHO, 40000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("17", "Bruno Guimarães", DateTime.Parse("1997-11-16"), 182, Pie.DERECHO, 40000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("14", "Danilo", DateTime.Parse("2001-04-29"), 177, Pie.IZQUIERDO, 22000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("8", "Fred", DateTime.Parse("1993-03-05"), 169, Pie.IZQUIERDO, 20000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("7", "Lucas Paquetá", DateTime.Parse("1997-08-27"), 18, Pie.IZQUIERDO, 35000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("20", "Vinicius Junior", DateTime.Parse("2000-07-12"), 176, Pie.DERECHO, 100000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("10", "Neymar", DateTime.Parse("1992-02-05"), 175, Pie.DERECHO, 75000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("22", "Gabriel Martinelli", DateTime.Parse("2001-06-18"), 176, Pie.DERECHO, 40000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("11", "Philippe Coutinho", DateTime.Parse("1992-06-12"), 172, Pie.DERECHO, 20000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("23", "Rodrygo", DateTime.Parse("2001-01-09"), 174, Pie.DERECHO, 60000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("19", "Raphinha", DateTime.Parse("1996-12-14"), 176, Pie.IZQUIERDO, 45000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("18", "Gabriel Jesus", DateTime.Parse("1997-04-03"), 175, Pie.DERECHO, 50000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("9", "Richarlison", DateTime.Parse("1997-05-10"), 184, Pie.DERECHO, 48000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("21", "Matheus Cunha", DateTime.Parse("1999-05-27"), 184, Pie.DERECHO, 30000000, Moneda.EUROS, Pais.GetPais("Brasil"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("16", "Mike Maignan", DateTime.Parse("1995-07-03"), 191, Pie.DERECHO, 35000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("23", "Alphonse Areola", DateTime.Parse("1993-02-27"), 195, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Hugo Lloris", DateTime.Parse("1986-12-26"), 188, Pie.IZQUIERDO, 7000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("5", "Jules Koundé", DateTime.Parse("1998-11-12"), 178, Pie.DERECHO, 60000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("21", "Lucas Hernández", DateTime.Parse("1996-02-14"), 184, Pie.IZQUIERDO, 50000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Raphaël Varane", DateTime.Parse("1993-04-25"), 191, Pie.DERECHO, 48000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("3", "Presnel Kimpembe", DateTime.Parse("1995-08-13"), 183, Pie.IZQUIERDO, 40000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Ibrahima Konaté", DateTime.Parse("1999-05-25"), 194, Pie.DERECHO, 40000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("17", "William Saliba", DateTime.Parse("2001-03-24"), 192, Pie.DERECHO, 30000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("22", "Theo Hernández", DateTime.Parse("1997-10-06"), 184, Pie.IZQUIERDO, 55000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("18", "Lucas Digne", DateTime.Parse("1993-07-20"), 178, Pie.IZQUIERDO, 25000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("2", "Benjamin Pavard", DateTime.Parse("1996-03-28"), 186, Pie.DERECHO, 30000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("15", "Jonathan Clauss", DateTime.Parse("1992-09-25"), 178, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("8", "Aurélien Tchouameni", DateTime.Parse("2000-01-27"), 188, Pie.DERECHO, 60000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("13", "N'Golo Kanté ", DateTime.Parse("1991-03-29"), 168, Pie.DERECHO, 40000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("13", "Boubacar Kamara", DateTime.Parse("1999-11-23"), 184, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("6", "Mattéo Guendouzi", DateTime.Parse("1999-04-14"), 185, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("14", "Adrien Rabiot", DateTime.Parse("1995-04-03"), 188, Pie.IZQUIERDO, 17000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("20", "Moussa Diaby", DateTime.Parse("1999-07-07"), 17, Pie.IZQUIERDO, 60000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("11", "Kingsley Coman ", DateTime.Parse("1996-06-13"), 18, Pie.DERECHO, 60000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("12", "Christopher Nkunku", DateTime.Parse("1997-11-14"), 175, Pie.DERECHO, 80000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.MEDIAPUNTA));
            Jugador.AltaJugador(new Jugador("7", "Antoine Griezmann", DateTime.Parse("1991-03-21"), 176, Pie.IZQUIERDO, 35000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.MEDIAPUNTA));
            Jugador.AltaJugador(new Jugador("10", "Kylian Mbappé", DateTime.Parse("1998-12-20"), 178, Pie.DERECHO, 160000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("19", "Karim Benzema", DateTime.Parse("1987-12-19"), 185, Pie.DERECHO, 30000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("9", "Wissam Ben Yedder", DateTime.Parse("1990-08-12"), 17, Pie.AMBIDIESTRO, 25000000, Moneda.EUROS, Pais.GetPais("Francia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("13", "Koen Casteels", DateTime.Parse("1992-06-25"), 197, Pie.IZQUIERDO, 11000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Matz Sels", DateTime.Parse("1992-02-26"), 188, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("12", "Simon Mignolet", DateTime.Parse("1988-03-06"), 193, Pie.DERECHO, 3500000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("3", "Arthur Theate", DateTime.Parse("2000-05-25"), 186, Pie.IZQUIERDO, 15000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Wout Faes", DateTime.Parse("1998-04-03"), 187, Pie.DERECHO, 10000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("2", "Toby Alderweireld ", DateTime.Parse("1989-03-02"), 187, Pie.DERECHO, 7000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Brandon Mechele", DateTime.Parse("1993-01-28"), 19, Pie.DERECHO, 6000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("5", "Jan Vertonghen", DateTime.Parse("1987-04-24"), 189, Pie.IZQUIERDO, 2000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("21", "Timothy Castagne", DateTime.Parse("1995-12-05"), 185, Pie.DERECHO, 28000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("15", "Thomas Foket", DateTime.Parse("1994-09-25"), 177, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("19", "Leander Dendoncker", DateTime.Parse("1995-04-15"), 188, Pie.DERECHO, 28000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("6", "Axel Witsel", DateTime.Parse("1989-01-12"), 186, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("8", "Youri Tielemans", DateTime.Parse("1997-05-07"), 176, Pie.DERECHO, 55000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("7", "Dennis Praet", DateTime.Parse("1994-05-14"), 181, Pie.DERECHO, 13000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("11", "Charles De Ketelaere", DateTime.Parse("2001-03-10"), 192, Pie.IZQUIERDO, 30000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("20", "Hans Vanaken", DateTime.Parse("1992-08-24"), 195, Pie.DERECHO, 16000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("17", "Leandro Trossard", DateTime.Parse("1994-12-04"), 172, Pie.DERECHO, 20000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("16", "Thorgan Hazard", DateTime.Parse("1993-03-29"), 175, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("10", "Eden Hazard", DateTime.Parse("1991-01-07"), 175, Pie.DERECHO, 12000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("22", "Alexis Saelemaekers", DateTime.Parse("1999-06-27"), 18, Pie.DERECHO, 17000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("18", "Adnan Januzaj", DateTime.Parse("1995-02-05"), 186, Pie.IZQUIERDO, 12000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("23", "Michy Batshuayi", DateTime.Parse("1993-10-02"), 185, Pie.DERECHO, 10000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("9", "Loïs Openda", DateTime.Parse("2000-02-16"), 175, Pie.DERECHO, 7500000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("14", "Dries Mertens", DateTime.Parse("1987-05-06"), 169, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Bélgica"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("1", "Dominik Livakovic", DateTime.Parse("1995-01-09"), 188, Pie.DERECHO, 8500000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("23", "Ivica Ivusic", DateTime.Parse("1995-02-01"), 195, Pie.DERECHO, 4500000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("12", "Nediljko Labrovic", DateTime.Parse("1999-10-10"), 196, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("5", "Duje Caleta-Car", DateTime.Parse("1996-09-17"), 192, Pie.DERECHO, 16000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("6", "Josip Sutalo", DateTime.Parse("2000-02-28"), 188, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("2", "Marin Pongracic", DateTime.Parse("1997-09-11"), 193, Pie.DERECHO, 6000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("20", "Martin Erlic", DateTime.Parse("1998-01-24"), 193, Pie.DERECHO, 5500000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("21", "Domagoj Vida", DateTime.Parse("1989-04-29"), 184, Pie.DERECHO, 1900000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("19", "Borna Sosa", DateTime.Parse("1998-01-21"), 187, Pie.IZQUIERDO, 23000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("3", "Borna Barisic", DateTime.Parse("1992-11-10"), 186, Pie.IZQUIERDO, 6000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("22", "Josip Juranovic", DateTime.Parse("1995-08-16"), 173, Pie.DERECHO, 7000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("2", "Sime Vrsaljko ", DateTime.Parse("1992-01-10"), 181, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("3", "Josip Stanisic", DateTime.Parse("2000-04-02"), 187, Pie.AMBIDIESTRO, 4000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("11", "Marcelo Brozovic", DateTime.Parse("1992-11-16"), 181, Pie.AMBIDIESTRO, 40000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("16", "Kristijan Jakic", DateTime.Parse("1997-05-14"), 181, Pie.DERECHO, 9000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("8", "Mateo Kovacic", DateTime.Parse("1994-05-06"), 176, Pie.DERECHO, 42000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("14", "Luka Sucic", DateTime.Parse("2002-09-08"), 185, Pie.IZQUIERDO, 20000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("10", "Luka Modric", DateTime.Parse("1985-09-09"), 172, Pie.AMBIDIESTRO, 10000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("15", "Mario Pasalic", DateTime.Parse("1995-02-09"), 188, Pie.DERECHO, 28000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("13", "Nikola Vlasic", DateTime.Parse("1997-10-04"), 178, Pie.DERECHO, 22000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("4", "Lovro Majer", DateTime.Parse("1998-01-17"), 176, Pie.IZQUIERDO, 20000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("19", "Luka Ivanusec", DateTime.Parse("1998-11-26"), 175, Pie.DERECHO, 12500000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("7", "Josip Brekalo", DateTime.Parse("1998-06-23"), 175, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("18", "Mislav Orsic", DateTime.Parse("1992-12-29"), 179, Pie.AMBIDIESTRO, 10000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("9", "Andrej Kramaric", DateTime.Parse("1991-06-19"), 177, Pie.DERECHO, 12000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Marko Livaja", DateTime.Parse("1993-08-26"), 184, Pie.DERECHO, 7500000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("17", "Ante Budimir", DateTime.Parse("1991-07-22"), 19, Pie.IZQUIERDO, 6000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Petar Musa", DateTime.Parse("1998-03-04"), 19, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Croacia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("23", "Unai Simón ", DateTime.Parse("1997-06-11"), 19, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("13", "David Raya", DateTime.Parse("1995-09-15"), 183, Pie.DERECHO, 22000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Robert Sánchez", DateTime.Parse("1997-11-18"), 197, Pie.DERECHO, 16000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("4", "Pau Torres", DateTime.Parse("1997-01-16"), 191, Pie.IZQUIERDO, 50000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("3", "Iñigo Martínez", DateTime.Parse("1991-05-17"), 182, Pie.IZQUIERDO, 25000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("14", "Eric García", DateTime.Parse("2001-01-09"), 182, Pie.DERECHO, 18000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("15", "Diego Llorente", DateTime.Parse("1993-08-16"), 186, Pie.DERECHO, 18000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("17", "Marcos Alonso", DateTime.Parse("1990-12-28"), 189, Pie.IZQUIERDO, 12000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("18", "Jordi Alba", DateTime.Parse("1989-03-21"), 17, Pie.IZQUIERDO, 9000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("20", "Daniel Carvajal", DateTime.Parse("1992-01-11"), 173, Pie.DERECHO, 18000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("2", "César Azpilicueta", DateTime.Parse("1989-08-28"), 178, Pie.DERECHO, 9000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("16", "Rodri", DateTime.Parse("1996-06-22"), 191, Pie.DERECHO, 80000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("5", "Sergio Busquets", DateTime.Parse("1988-07-16"), 189, Pie.DERECHO, 9000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("9", "Gavi", DateTime.Parse("2004-08-05"), 173, Pie.DERECHO, 60000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("19", "Carlos Soler", DateTime.Parse("1997-01-02"), 18, Pie.DERECHO, 50000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("6", "Marcos Llorente", DateTime.Parse("1995-01-30"), 184, Pie.DERECHO, 45000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("8", "Koke", DateTime.Parse("1992-01-08"), 176, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("21", "Dani Olmo", DateTime.Parse("1998-05-07"), 179, Pie.DERECHO, 40000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("12", "Ansu Fati", DateTime.Parse("2002-10-31"), 178, Pie.DERECHO, 60000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("11", "Ferran Torres", DateTime.Parse("2000-02-29"), 184, Pie.DERECHO, 45000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("10", "Marco Asensio", DateTime.Parse("1996-01-21"), 182, Pie.IZQUIERDO, 40000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("22", "Pablo Sarabia", DateTime.Parse("1992-05-11"), 174, Pie.IZQUIERDO, 25000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("7", "Álvaro Morata", DateTime.Parse("1992-10-23"), 187, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("14", "Raúl de Tomás", DateTime.Parse("1994-10-17"), 18, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("España"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("12", "Predrag Rajković ", DateTime.Parse("1995-10-31"), 192, Pie.DERECHO, 9000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Marko Dmitrović", DateTime.Parse("1992-01-24"), 194, Pie.IZQUIERDO, 5000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("23", "Vanja Milinković-Savić", DateTime.Parse("1997-02-20"), 202, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("4", "Nikola Milenković", DateTime.Parse("1997-10-12"), 195, Pie.DERECHO, 20000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("2", "Strahinja Pavlovic", DateTime.Parse("2001-05-24"), 194, Pie.IZQUIERDO, 5000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("5", "Strahinja Erakovic", DateTime.Parse("2001-01-22"), 186, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("15", "Milos Veljkovic", DateTime.Parse("1995-09-26"), 188, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("3", "Erhan Masovic", DateTime.Parse("1998-11-22"), 189, Pie.AMBIDIESTRO, 2500000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("13", "Stefan Mitrović", DateTime.Parse("1990-05-22"), 189, Pie.AMBIDIESTRO, 1800000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("19", "Mihailo Ristic", DateTime.Parse("1995-10-31"), 18, Pie.IZQUIERDO, 3500000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("14", "Aleksa Terzić", DateTime.Parse("1999-08-17"), 184, Pie.IZQUIERDO, 1500000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("3", "Filip Mladenovic", DateTime.Parse("1991-08-15"), 18, Pie.IZQUIERDO, 1200000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("6", "Nemanja Maksimović", DateTime.Parse("1995-01-26"), 189, Pie.DERECHO, 14000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("18", "Uroš Račić", DateTime.Parse("1998-03-17"), 193, Pie.AMBIDIESTRO, 7000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("8", "Nemanja Gudelj", DateTime.Parse("1991-11-16"), 187, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("20", "Sergej Milinković-Savić", DateTime.Parse("1995-02-27"), 191, Pie.DERECHO, 70000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("16", "Saša Lukić", DateTime.Parse("1996-08-13"), 183, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("6", "Ivan Ilić", DateTime.Parse("2001-03-17"), 185, Pie.IZQUIERDO, 14000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("22", "Marko Grujic", DateTime.Parse("1996-04-13"), 191, Pie.DERECHO, 12000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("17", "Filip Kostic", DateTime.Parse("1992-11-01"), 184, Pie.IZQUIERDO, 24000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.INTERIOR_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("22", "Darko Lazović", DateTime.Parse("1990-09-15"), 181, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.INTERIOR_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("21", "Filip Djuricic", DateTime.Parse("1992-01-30"), 181, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("10", "Dusan Tadić", DateTime.Parse("1988-11-20"), 181, Pie.IZQUIERDO, 12000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("7", "Nemanja Radonjić", DateTime.Parse("1996-02-15"), 185, Pie.AMBIDIESTRO, 4000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("14", "Andrija Zivkovic", DateTime.Parse("1996-07-11"), 169, Pie.IZQUIERDO, 6000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("18", "Dušan Vlahović", DateTime.Parse("2000-01-28"), 19, Pie.IZQUIERDO, 85000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("9", "Aleksandar Mitrović", DateTime.Parse("1994-09-16"), 189, Pie.DERECHO, 20000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("11", "Luka Jović", DateTime.Parse("1997-12-23"), 182, Pie.AMBIDIESTRO, 16000000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("9", "Djordje Jovanovic", DateTime.Parse("1999-02-15"), 187, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Serbia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Aaron Ramsdale", DateTime.Parse("1998-05-14"), 19, Pie.DERECHO, 28000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Jordan Pickford", DateTime.Parse("1994-03-07"), 185, Pie.IZQUIERDO, 20000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Nick Pope", DateTime.Parse("1992-04-19"), 198, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Fikayo Tomori", DateTime.Parse("1997-12-19"), 185, Pie.DERECHO, 50000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Ben White", DateTime.Parse("1997-10-08"), 186, Pie.DERECHO, 40000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Harry Maguire", DateTime.Parse("1993-03-05"), 194, Pie.DERECHO, 38000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Marc Guéhi", DateTime.Parse("2000-07-13"), 182, Pie.DERECHO, 32000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "John Stones ", DateTime.Parse("1994-05-28"), 188, Pie.DERECHO, 28000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Conor Coady", DateTime.Parse("1993-02-25"), 185, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Trent Alexander-Arnold", DateTime.Parse("1998-10-07"), 18, Pie.DERECHO, 80000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Reece James", DateTime.Parse("1999-12-08"), 18, Pie.DERECHO, 60000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "James Justin", DateTime.Parse("1998-02-23"), 183, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Kyle Walker", DateTime.Parse("1990-05-28"), 183, Pie.DERECHO, 18000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Kieran Trippier", DateTime.Parse("1990-09-19"), 173, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Declan Rice ", DateTime.Parse("1999-01-14"), 188, Pie.DERECHO, 80000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Kalvin Phillips", DateTime.Parse("1995-12-02"), 179, Pie.DERECHO, 50000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Phil Foden", DateTime.Parse("2000-05-28"), 171, Pie.IZQUIERDO, 90000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Jude Bellingham", DateTime.Parse("2003-06-29"), 186, Pie.DERECHO, 80000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "James Ward-Prowse", DateTime.Parse("1994-11-01"), 177, Pie.DERECHO, 32000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Conor Gallagher", DateTime.Parse("2000-02-06"), 182, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Bukayo Saka", DateTime.Parse("2001-09-05"), 178, Pie.IZQUIERDO, 65000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.INTERIOR_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Mason Mount", DateTime.Parse("1999-01-10"), 18, Pie.DERECHO, 75000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Raheem Sterling", DateTime.Parse("1994-12-08"), 17, Pie.DERECHO, 70000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Jack Grealish", DateTime.Parse("1995-09-10"), 18, Pie.DERECHO, 70000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Jarrod Bowen", DateTime.Parse("1996-12-20"), 182, Pie.IZQUIERDO, 42000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Harry Kane", DateTime.Parse("1993-07-28"), 188, Pie.DERECHO, 90000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Tammy Abraham", DateTime.Parse("1997-10-02"), 194, Pie.DERECHO, 50000000, Moneda.EUROS, Pais.GetPais("Inglaterra"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("21", "Gregor Kobel", DateTime.Parse("1997-12-06"), 194, Pie.DERECHO, 22000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("12", "Jonas Omlin", DateTime.Parse("1994-01-10"), 19, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Yann Sommer", DateTime.Parse("1988-12-17"), 183, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("12", "Yvon Mvogo", DateTime.Parse("1994-06-06"), 189, Pie.DERECHO, 2800000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("5", "Manuel Akanji", DateTime.Parse("1995-07-19"), 188, Pie.DERECHO, 30000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Nico Elvedi", DateTime.Parse("1996-09-30"), 189, Pie.DERECHO, 18000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("22", "Fabian Schär", DateTime.Parse("1991-12-20"), 186, Pie.DERECHO, 7000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Leonidas Stergiou", DateTime.Parse("2002-03-03"), 181, Pie.DERECHO, 6000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("13", "Ricardo Rodríguez", DateTime.Parse("1992-08-25"), 18, Pie.IZQUIERDO, 3400000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("18", "Eray Cömert", DateTime.Parse("1998-02-04"), 183, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("2", "Kevin Mbabu", DateTime.Parse("1995-04-19"), 184, Pie.DERECHO, 9000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("16", "Jordan Lotomba", DateTime.Parse("1998-09-29"), 177, Pie.DERECHO, 7000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("3", "Silvan Widmer", DateTime.Parse("1993-03-05"), 183, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("10", "Granit Xhaka", DateTime.Parse("1992-09-27"), 186, Pie.IZQUIERDO, 20000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("6", "Fabian Frei", DateTime.Parse("1989-01-08"), 183, Pie.DERECHO, 500000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("15", "Djibril Sow", DateTime.Parse("1997-02-06"), 184, Pie.DERECHO, 22000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("8", "Remo Freuler", DateTime.Parse("1992-04-15"), 18, Pie.DERECHO, 20000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("20", "Michel Aebischer", DateTime.Parse("1997-01-06"), 183, Pie.DERECHO, 3500000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("14", "Mattia Bottani", DateTime.Parse("1991-05-24"), 17, Pie.DERECHO, 500000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("17", "Rubén Vargas ", DateTime.Parse("1998-08-05"), 179, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("14", "Steven Zuber", DateTime.Parse("1991-08-17"), 182, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("11", "Renato Steffen", DateTime.Parse("1991-11-03"), 17, Pie.IZQUIERDO, 2000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("23", "Xherdan Shaqiri", DateTime.Parse("1991-10-10"), 169, Pie.IZQUIERDO, 7000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("5", "Noah Okafor", DateTime.Parse("2000-05-24"), 185, Pie.DERECHO, 18000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("7", "Breel Embolo", DateTime.Parse("1997-02-14"), 187, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("9", "Haris Seferovic", DateTime.Parse("1992-02-22"), 189, Pie.IZQUIERDO, 8000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Zeki Amdouni", DateTime.Parse("2000-12-04"), 185, Pie.NO_DEFINIDO, 2000000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("19", "Mario Gavranovic", DateTime.Parse("1989-11-24"), 175, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("Suiza"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("13", "Mark Flekken", DateTime.Parse("1993-06-13"), 194, Pie.AMBIDIESTRO, 7000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Jasper Cillessen", DateTime.Parse("1989-04-22"), 187, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("23", "Kjell Scherpen", DateTime.Parse("2000-01-23"), 204, Pie.DERECHO, 2200000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("3", "Matthijs de Ligt", DateTime.Parse("1999-08-12"), 189, Pie.DERECHO, 70000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Jurrien Timber", DateTime.Parse("2001-06-17"), 182, Pie.DERECHO, 35000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("6", "Stefan de Vrij", DateTime.Parse("1992-02-05"), 189, Pie.DERECHO, 28000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Nathan Aké", DateTime.Parse("1995-02-18"), 18, Pie.IZQUIERDO, 25000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("2", "Jordan Teze", DateTime.Parse("1999-09-30"), 183, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Bruno Martins Indi", DateTime.Parse("1992-02-08"), 185, Pie.IZQUIERDO, 2200000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Ernest Faber", DateTime.Parse("1971-08-27"), 184, Pie.DERECHO, 0, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("5", "Tyrell Malacia", DateTime.Parse("1999-08-17"), 169, Pie.IZQUIERDO, 17000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("17", "Daley Blind", DateTime.Parse("1990-03-09"), 18, Pie.IZQUIERDO, 9000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("15", "Hans Hateboer", DateTime.Parse("1994-01-09"), 185, Pie.DERECHO, 13000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("20", "Teun Koopmeiners", DateTime.Parse("1998-02-28"), 183, Pie.IZQUIERDO, 25000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("18", "Jerdy Schouten", DateTime.Parse("1997-01-12"), 185, Pie.DERECHO, 9000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("21", "Frenkie de Jong", DateTime.Parse("1997-05-12"), 18, Pie.DERECHO, 60000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("22", "Denzel Dumfries", DateTime.Parse("1996-04-18"), 188, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.INTERIOR_DERECHO));
            Jugador.AltaJugador(new Jugador("11", "Steven Berghuis", DateTime.Parse("1991-12-19"), 182, Pie.IZQUIERDO, 14000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("14", "Davy Klaassen", DateTime.Parse("1993-02-21"), 179, Pie.DERECHO, 14000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("8", "Guus Til", DateTime.Parse("1997-12-22"), 186, Pie.DERECHO, 7500000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("9", "Cody Gakpo", DateTime.Parse("1999-05-07"), 189, Pie.DERECHO, 30000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("12", "Noa Lang", DateTime.Parse("1999-06-17"), 173, Pie.DERECHO, 22000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("7", "Steven Bergwijn", DateTime.Parse("1997-10-08"), 178, Pie.DERECHO, 18000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("10", "Memphis Depay", DateTime.Parse("1994-02-13"), 176, Pie.DERECHO, 35000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("19", "Wout Weghorst", DateTime.Parse("1992-08-07"), 197, Pie.DERECHO, 14000000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("16", "Vincent Janssen", DateTime.Parse("1994-06-15"), 184, Pie.IZQUIERDO, 2500000, Moneda.EUROS, Pais.GetPais("Países Bajos"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("22", "Amir Abedzadeh", DateTime.Parse("1993-04-26"), 187, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Alireza Beiranvand", DateTime.Parse("1992-09-21"), 194, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("30", "Payam Niazmand", DateTime.Parse("1995-04-06"), 194, Pie.DERECHO, 500000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("12", "Hossein Hosseini", DateTime.Parse("1992-06-30"), 189, Pie.DERECHO, 450000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("19", "Majid Hosseini", DateTime.Parse("1996-06-20"), 187, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Aref Gholami", DateTime.Parse("1997-04-19"), 183, Pie.DERECHO, 600000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("29", "Armin Sohrabian", DateTime.Parse("1995-07-26"), 181, Pie.IZQUIERDO, 550000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("13", "Aref Aghasi", DateTime.Parse("1997-01-02"), 184, Pie.IZQUIERDO, 450000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("21", "Omid Noorafkan", DateTime.Parse("1997-04-09"), 182, Pie.IZQUIERDO, 1200000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("3", "Ehsan Hajsafi", DateTime.Parse("1990-02-25"), 178, Pie.IZQUIERDO, 800000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("16", "Abolfazl Jalali", DateTime.Parse("1998-06-26"), 177, Pie.IZQUIERDO, 250000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("2", "Sadegh Moharrami", DateTime.Parse("1996-03-01"), 174, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("5", "Saleh Hardani", DateTime.Parse("1998-09-14"), 176, Pie.DERECHO, 700000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("26", "Mehdi Shiri", DateTime.Parse("1991-01-31"), 176, Pie.DERECHO, 250000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("18", "Milad Sarlak", DateTime.Parse("1995-03-26"), 181, Pie.DERECHO, 900000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("6", "Saeid Ezatolahi", DateTime.Parse("1996-10-01"), 19, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("14", "Omid Ebrahimi", DateTime.Parse("1987-09-16"), 178, Pie.DERECHO, 325000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("8", "Ahmad Nourollahi", DateTime.Parse("1993-02-01"), 185, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("23", "Mehdi Mehdipour", DateTime.Parse("1994-10-25"), 182, Pie.DERECHO, 775000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("28", "Seyed Mehdi Hosseini", DateTime.Parse("1993-09-16"), 172, Pie.DERECHO, 350000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("15", "Amirhossein Hosseinzadeh", DateTime.Parse("2000-10-30"), 178, Pie.DERECHO, 850000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("24", "Soroosh Rafiei", DateTime.Parse("1990-03-24"), 175, Pie.DERECHO, 500000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("27", "Mehdi Torabi", DateTime.Parse("1994-09-10"), 185, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("7", "Alireza Jahanbakhsh", DateTime.Parse("1993-08-11"), 0, Pie.NO_DEFINIDO, 3500000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("17", "Ali Gholizadeh", DateTime.Parse("1996-03-10"), 176, Pie.IZQUIERDO, 3000000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("25", "Saeid Sadeghi", DateTime.Parse("1994-04-25"), 18, Pie.DERECHO, 900000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("20", "Sardar Azmoun", DateTime.Parse("1995-01-01"), 186, Pie.AMBIDIESTRO, 22000000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("9", "Mehdi Taremi", DateTime.Parse("1992-07-18"), 187, Pie.DERECHO, 20000000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("10", "Allahyar Sayyadmanesh", DateTime.Parse("2001-06-29"), 182, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("11", "Ali Alipour", DateTime.Parse("1995-11-11"), 181, Pie.AMBIDIESTRO, 1500000, Moneda.EUROS, Pais.GetPais("Irán"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("21", "Hyeon-woo Jo", DateTime.Parse("1991-09-25"), 189, Pie.DERECHO, 1400000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("12", "Bum-keun Song", DateTime.Parse("1997-10-15"), 194, Pie.NO_DEFINIDO, 950000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Dong-jun Kim", DateTime.Parse("1994-12-19"), 189, Pie.NO_DEFINIDO, 550000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("18", "Ji-soo Park", DateTime.Parse("1994-06-13"), 187, Pie.DERECHO, 750000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("20", "Kyung-won Kwon", DateTime.Parse("1992-01-31"), 189, Pie.IZQUIERDO, 750000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Yu-min Cho", DateTime.Parse("1996-11-17"), 184, Pie.DERECHO, 625000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("19", "Young-gwon Kim", DateTime.Parse("1990-02-27"), 186, Pie.IZQUIERDO, 600000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("24", "Ju-sung Kim ", DateTime.Parse("2000-12-12"), 188, Pie.IZQUIERDO, 500000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("3", "Jin-su Kim", DateTime.Parse("1992-06-13"), 177, Pie.IZQUIERDO, 600000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("14", "Chul Hong", DateTime.Parse("1990-09-17"), 176, Pie.IZQUIERDO, 525000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("15", "Moon-hwan Kim", DateTime.Parse("1995-08-01"), 173, Pie.DERECHO, 950000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("2", "Jong-gyu Yoon", DateTime.Parse("1998-03-20"), 173, Pie.DERECHO, 600000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("16", "Dong-hyeon Kim", DateTime.Parse("1997-06-11"), 182, Pie.DERECHO, 700000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("6", "In-beom Hwang ", DateTime.Parse("1996-09-20"), 177, Pie.NO_DEFINIDO, 3000000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("8", "Seung-ho Paik", DateTime.Parse("1997-03-17"), 182, Pie.NO_DEFINIDO, 925000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("5", "Yeong-jae Lee", DateTime.Parse("1994-09-13"), 174, Pie.IZQUIERDO, 850000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("10", "Jin-gyu Kim", DateTime.Parse("1997-02-24"), 176, Pie.DERECHO, 600000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("25", "Gi-hyuk Lee", DateTime.Parse("2000-07-07"), 184, Pie.NO_DEFINIDO, 200000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("23", "Young-jun Goh", DateTime.Parse("2001-07-09"), 168, Pie.DERECHO, 500000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("13", "Min-kyu Song", DateTime.Parse("1999-09-12"), 181, Pie.DERECHO, 1300000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("7", "Sang-ho Na", DateTime.Parse("1996-08-12"), 173, Pie.DERECHO, 900000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("22", "Chang-hoon Kwon", DateTime.Parse("1994-06-30"), 173, Pie.IZQUIERDO, 1500000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("11", "Won-sang Um", DateTime.Parse("1999-01-06"), 171, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("17", "Young-wook Cho", DateTime.Parse("1999-02-05"), 178, Pie.DERECHO, 700000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("26", "Seong-jin Kang", DateTime.Parse("2003-03-26"), 18, Pie.DERECHO, 425000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("9", "Gue-sung Cho ", DateTime.Parse("1998-01-25"), 188, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Corea del Sur"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("1", "Keisuke Osako", DateTime.Parse("1999-07-28"), 187, Pie.DERECHO, 850000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("12", "Kosei Tani", DateTime.Parse("2000-11-22"), 19, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("23", "Zion Suzuki", DateTime.Parse("2002-08-21"), 19, Pie.DERECHO, 300000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("3", "Shogo Taniguchi", DateTime.Parse("1991-07-15"), 183, Pie.DERECHO, 1700000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Shinnosuke Nakatani", DateTime.Parse("1996-03-24"), 184, Pie.DERECHO, 1300000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("5", "Shinnosuke Hatanaka", DateTime.Parse("1995-08-25"), 184, Pie.AMBIDIESTRO, 1000000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("6", "Tomoki Iwata", DateTime.Parse("1997-04-07"), 176, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("19", "Sho Sasaki", DateTime.Parse("1989-10-02"), 176, Pie.DERECHO, 900000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("22", "Hayato Araki", DateTime.Parse("1996-08-07"), 186, Pie.DERECHO, 900000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("24", "Takuma Ominami", DateTime.Parse("1997-12-13"), 184, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("13", "Daiki Sugioka", DateTime.Parse("1998-09-08"), 182, Pie.IZQUIERDO, 550000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("2", "Miki Yamane", DateTime.Parse("1993-12-22"), 178, Pie.DERECHO, 1300000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("25", "Ryuta Koike", DateTime.Parse("1995-08-29"), 169, Pie.DERECHO, 900000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("26", "Joel Chima Fujita", DateTime.Parse("2002-02-16"), 173, Pie.DERECHO, 700000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("15", "Kento Hashimoto", DateTime.Parse("1993-08-16"), 183, Pie.DERECHO, 2200000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("18", "Kota Mizunuma", DateTime.Parse("1990-02-22"), 176, Pie.DERECHO, 850000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.INTERIOR_DERECHO));
            Jugador.AltaJugador(new Jugador("8", "Tsukasa Morishima", DateTime.Parse("1997-04-25"), 173, Pie.DERECHO, 1300000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("14", "Yasuto Wakizaka", DateTime.Parse("1995-06-11"), 172, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("7", "Gakuto Notsuda", DateTime.Parse("1994-06-06"), 175, Pie.IZQUIERDO, 700000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("16", "Yuki Soma", DateTime.Parse("1997-02-25"), 166, Pie.DERECHO, 900000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("10", "Yuto Iwasaki", DateTime.Parse("1998-06-11"), 172, Pie.DERECHO, 500000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("21", "Makoto Mitsuta", DateTime.Parse("1999-07-20"), 17, Pie.DERECHO, 450000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("17", "Ryo Miyaichi ", DateTime.Parse("1992-12-14"), 183, Pie.DERECHO, 400000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("9", "Takuma Nishimura", DateTime.Parse("1996-10-22"), 178, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.MEDIAPUNTA));
            Jugador.AltaJugador(new Jugador("11", "Shuto Machino", DateTime.Parse("1999-09-30"), 184, Pie.AMBIDIESTRO, 700000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("20", "Mao Hosoya", DateTime.Parse("2001-09-07"), 177, Pie.DERECHO, 550000, Moneda.EUROS, Pais.GetPais("Japón"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Mohammed Al-Rubaie", DateTime.Parse("1997-08-14"), 19, Pie.DERECHO, 1200000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Mohammed Al-Owais", DateTime.Parse("1991-10-10"), 185, Pie.IZQUIERDO, 900000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Fawaz Al-Qarni", DateTime.Parse("1992-04-02"), 185, Pie.DERECHO, 350000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Amin Al-Bukhari", DateTime.Parse("1997-05-02"), 194, Pie.DERECHO, 175000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Ziyad Al-Sahafi", DateTime.Parse("1994-10-17"), 182, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Abdulelah Al-Amri", DateTime.Parse("1997-01-15"), 183, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Ali Al-Oujami", DateTime.Parse("1996-04-25"), 175, Pie.DERECHO, 750000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("12", "Hassan Tambakti", DateTime.Parse("1999-02-09"), 182, Pie.DERECHO, 600000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Ali Al-Boleahi", DateTime.Parse("1989-11-21"), 178, Pie.IZQUIERDO, 400000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Yasser Al-Shahrani", DateTime.Parse("1992-05-25"), 171, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Sultan Al-Ghannam", DateTime.Parse("1994-05-06"), 173, Pie.DERECHO, 3500000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Mohammed Al-Burayk", DateTime.Parse("1992-09-15"), 17, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Nasser Al-Dawsari", DateTime.Parse("1998-12-19"), 178, Pie.IZQUIERDO, 350000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Ali Al-Hassan", DateTime.Parse("1997-03-04"), 176, Pie.DERECHO, 300000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Abdullah Otayf", DateTime.Parse("1992-08-03"), 177, Pie.DERECHO, 300000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Mohamed Kanno", DateTime.Parse("1994-09-22"), 192, Pie.DERECHO, 1800000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Salman Al-Faraj", DateTime.Parse("1989-08-01"), 18, Pie.IZQUIERDO, 750000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Sami Al-Najei", DateTime.Parse("1997-02-07"), 181, Pie.IZQUIERDO, 900000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Abdulrahman Ghareeb", DateTime.Parse("1997-03-31"), 164, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Salem Al-Dawsari", DateTime.Parse("1991-08-19"), 171, Pie.DERECHO, 2800000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Khalid Al-Ghannam", DateTime.Parse("2000-11-08"), 171, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Abdulaziz Al-Bishi", DateTime.Parse("1994-03-11"), 172, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("20", "Abdulrahman Al-Obood", DateTime.Parse("1995-06-10"), 174, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Hattan Bahebri", DateTime.Parse("1992-07-16"), 17, Pie.DERECHO, 900000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Firas Al-Buraikan", DateTime.Parse("2000-05-14"), 181, Pie.IZQUIERDO, 1200000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Abdullah Al-Hamdan", DateTime.Parse("1999-09-12"), 184, Pie.AMBIDIESTRO, 375000, Moneda.EUROS, Pais.GetPais("Arabia Saudita"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("12", "Moisés Ramírez", DateTime.Parse("2000-09-09"), 185, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Hernán Galíndez", DateTime.Parse("1987-03-30"), 188, Pie.DERECHO, 600000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("22", "Alexander Domínguez", DateTime.Parse("1987-06-05"), 196, Pie.DERECHO, 350000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("3", "Piero Hincapié", DateTime.Parse("2002-01-09"), 184, Pie.IZQUIERDO, 17000000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("2", "Félix Torres", DateTime.Parse("1997-01-11"), 187, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("14", "Jackson Porozo", DateTime.Parse("2000-08-04"), 192, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Robert Arboleda ", DateTime.Parse("1991-10-22"), 187, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("14", "Xavier Arreaga", DateTime.Parse("1994-09-28"), 183, Pie.NO_DEFINIDO, 1500000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("7", "Pervis Estupiñán", DateTime.Parse("1998-01-21"), 175, Pie.IZQUIERDO, 20000000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("18", "Diego Palacios", DateTime.Parse("1999-07-12"), 169, Pie.IZQUIERDO, 3500000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("6", "Byron Castillo", DateTime.Parse("1998-11-10"), 167, Pie.DERECHO, 2800000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("17", "Angelo Preciado", DateTime.Parse("1998-02-18"), 173, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("8", "Carlos Gruezo", DateTime.Parse("1995-04-19"), 171, Pie.DERECHO, 3200000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("20", "Jhegson Méndez", DateTime.Parse("1997-04-26"), 171, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("5", "Dixon Arroyo", DateTime.Parse("1992-06-01"), 179, Pie.DERECHO, 900000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("5", "José Cifuentes", DateTime.Parse("1999-03-12"), 175, Pie.DERECHO, 6500000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("23", "Moisés Caicedo", DateTime.Parse("2001-11-02"), 178, Pie.DERECHO, 6000000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("21", "Alan Franco", DateTime.Parse("1998-08-21"), 174, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("16", "Jeremy Sarmiento", DateTime.Parse("2002-06-16"), 183, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("10", "Romario Ibarra", DateTime.Parse("1994-09-24"), 176, Pie.DERECHO, 1800000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("5", "Alexander Alvarado ", DateTime.Parse("1999-04-21"), 165, Pie.DERECHO, 1200000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("19", "Gonzalo Plata", DateTime.Parse("2000-11-01"), 178, Pie.IZQUIERDO, 6000000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("15", "Ángel Mena", DateTime.Parse("1988-01-21"), 168, Pie.IZQUIERDO, 1800000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("11", "Michael Estrada", DateTime.Parse("1996-04-07"), 188, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("13", "Enner Valencia", DateTime.Parse("1989-11-04"), 177, Pie.DERECHO, 2400000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("11", "Jordy Caicedo", DateTime.Parse("1997-11-18"), 187, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("9", "Leonardo Campana", DateTime.Parse("2000-07-24"), 188, Pie.IZQUIERDO, 1200000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("10", "Djorkaeff Reasco", DateTime.Parse("1999-01-18"), 172, Pie.DERECHO, 700000, Moneda.EUROS, Pais.GetPais("Ecuador"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("12", "Sergio Rochet", DateTime.Parse("1993-03-23"), 19, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("23", "Sebastián Sosa", DateTime.Parse("1986-08-19"), 181, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Fernando Muslera", DateTime.Parse("1986-06-16"), 19, Pie.DERECHO, 1800000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("2", "José María Giménez ", DateTime.Parse("1995-01-20"), 185, Pie.DERECHO, 50000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Ronald Araújo", DateTime.Parse("1999-03-07"), 188, Pie.DERECHO, 50000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("19", "Sebastián Coates", DateTime.Parse("1990-10-07"), 196, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("3", "Diego Godín", DateTime.Parse("1986-02-16"), 187, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("22", "Martín Cáceres", DateTime.Parse("1987-04-07"), 18, Pie.DERECHO, 900000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("16", "Mathías Olivera", DateTime.Parse("1997-10-31"), 185, Pie.IZQUIERDO, 15000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("17", "Matías Viña", DateTime.Parse("1997-11-09"), 18, Pie.IZQUIERDO, 7500000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("4", "Guillermo Varela", DateTime.Parse("1993-03-24"), 173, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("4", "Luis Suárez", DateTime.Parse("1987-01-24"), 182, Pie.DERECHO, 28000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("13", "Damián Suárez", DateTime.Parse("1988-04-27"), 173, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("14", "Lucas Torreira", DateTime.Parse("1996-02-11"), 166, Pie.DERECHO, 20000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("6", "Manuel Ugarte", DateTime.Parse("2001-04-11"), 182, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("15", "Federico Valverde", DateTime.Parse("1998-07-22"), 182, Pie.DERECHO, 70000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("20", "Mauro Arambarri", DateTime.Parse("1995-09-30"), 175, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("7", "Nicolás de la Cruz", DateTime.Parse("1997-06-01"), 167, Pie.DERECHO, 13000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("11", "Fernando Gorriarán", DateTime.Parse("1994-11-27"), 168, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("5", "Matías Vecino", DateTime.Parse("1991-08-24"), 187, Pie.DERECHO, 3500000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("10", "Giorgian de Arrascaeta", DateTime.Parse("1994-06-01"), 174, Pie.DERECHO, 17000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("8", "Diego Rossi", DateTime.Parse("1998-03-05"), 17, Pie.DERECHO, 14500000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("8", "Facundo Pellistri", DateTime.Parse("2001-12-20"), 174, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Agustín Canobbio", DateTime.Parse("1998-10-01"), 175, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Augusto Scarone", DateTime.Parse("2004-06-03"), 17, Pie.IZQUIERDO, 300000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.MEDIAPUNTA));
            Jugador.AltaJugador(new Jugador("11", "Darwin Núñez", DateTime.Parse("1999-06-24"), 187, Pie.DERECHO, 55000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("18", "Maxi Gómez", DateTime.Parse("1996-08-14"), 186, Pie.DERECHO, 12000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("21", "Edinson Cavani", DateTime.Parse("1987-02-14"), 184, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Uruguay"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Maxime Crépeau", DateTime.Parse("1994-05-11"), 185, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("18", "Milan Borjan", DateTime.Parse("1987-10-23"), 196, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Dayne St. Clair", DateTime.Parse("1997-05-09"), 191, Pie.IZQUIERDO, 1000000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Kamal Miller", DateTime.Parse("1997-05-16"), 183, Pie.IZQUIERDO, 2500000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Doneil Henry", DateTime.Parse("1993-04-20"), 188, Pie.DERECHO, 750000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Scott Kennedy", DateTime.Parse("1997-03-31"), 19, Pie.IZQUIERDO, 600000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Steven Vitória", DateTime.Parse("1987-01-11"), 195, Pie.DERECHO, 100000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("19", "Alphonso Davies", DateTime.Parse("2000-11-02"), 183, Pie.IZQUIERDO, 70000000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Sam Adekugbe", DateTime.Parse("1995-01-16"), 176, Pie.IZQUIERDO, 2000000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Raheem Edwards", DateTime.Parse("1995-07-17"), 172, Pie.NO_DEFINIDO, 450000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Alistair Johnston", DateTime.Parse("1998-10-08"), 18, Pie.NO_DEFINIDO, 3000000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Richie Laryea", DateTime.Parse("1995-01-07"), 175, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Stephen Eustaquio", DateTime.Parse("1996-12-21"), 177, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Samuel Piette", DateTime.Parse("1994-11-12"), 171, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Mark-Anthony Kaye", DateTime.Parse("1994-12-02"), 185, Pie.IZQUIERDO, 5000000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Jonathan Osorio", DateTime.Parse("1992-06-12"), 175, Pie.AMBIDIESTRO, 3500000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("13", "Atiba Hutchinson", DateTime.Parse("1983-02-08"), 187, Pie.DERECHO, 275000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Cyle Larin", DateTime.Parse("1995-04-17"), 188, Pie.DERECHO, 10000000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Junior Hoilett", DateTime.Parse("1990-06-05"), 174, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Luca Koleosho", DateTime.Parse("2004-09-15"), 0, Pie.DERECHO, 0, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Tajon Buchanan ", DateTime.Parse("1999-02-08"), 183, Pie.DERECHO, 9500000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Jonathan David", DateTime.Parse("2000-01-14"), 18, Pie.AMBIDIESTRO, 45000000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Iké Ugbo", DateTime.Parse("1998-09-21"), 184, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Lucas Cavallini", DateTime.Parse("1992-12-28"), 182, Pie.IZQUIERDO, 3000000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Charles-Andreas Brym", DateTime.Parse("1998-08-08"), 185, Pie.IZQUIERDO, 325000, Moneda.EUROS, Pais.GetPais("Canadá"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("12", "Lawrence Ati Zigi", DateTime.Parse("1996-11-29"), 189, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Abdul Nurudeen", DateTime.Parse("1999-02-08"), 19, Pie.DERECHO, 600000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("16", "Joe Wollacott", DateTime.Parse("1996-09-08"), 19, Pie.NO_DEFINIDO, 300000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Ibrahim Danlad", DateTime.Parse("2002-12-02"), 177, Pie.DERECHO, 100000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("18", "Daniel Amartey", DateTime.Parse("1994-12-21"), 186, Pie.DERECHO, 10000000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("6", "Joseph Aidoo", DateTime.Parse("1995-09-29"), 177, Pie.DERECHO, 7000000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("26", "Abdul Mumin", DateTime.Parse("1998-06-06"), 188, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Patric Pfeiffer", DateTime.Parse("1999-08-20"), 196, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Alidu Seidu", DateTime.Parse("2000-06-04"), 173, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Jonathan Mensah", DateTime.Parse("1990-07-13"), 188, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Stephan Ambrosius", DateTime.Parse("1998-12-18"), 183, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("14", "Gideon Mensah", DateTime.Parse("1998-07-18"), 178, Pie.IZQUIERDO, 2500000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Abdul-Rahman Baba", DateTime.Parse("1994-07-02"), 179, Pie.IZQUIERDO, 2200000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Andy Yiadom", DateTime.Parse("1991-12-02"), 18, Pie.DERECHO, 1200000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("3", "Denis Odoi", DateTime.Parse("1988-05-27"), 178, Pie.DERECHO, 700000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("10", "Elisha Owusu", DateTime.Parse("1997-11-07"), 182, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Edmund Addo", DateTime.Parse("2000-05-17"), 18, Pie.DERECHO, 1100000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("20", "Mohammed Kudus", DateTime.Parse("2000-08-02"), 177, Pie.IZQUIERDO, 10000000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("21", "Iddrisu Baba", DateTime.Parse("1996-01-22"), 182, Pie.DERECHO, 3500000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Mubarak Wakaso", DateTime.Parse("1990-07-25"), 171, Pie.IZQUIERDO, 2000000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("8", "Daniel-Kofi Kyereh", DateTime.Parse("1996-03-08"), 179, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("7", "Issahaku Fatawu", DateTime.Parse("2004-03-08"), 177, Pie.IZQUIERDO, 500000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Augustine Okrah", DateTime.Parse("1993-09-14"), 172, Pie.IZQUIERDO, 150000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("22", "Kamaldeen Sulemana", DateTime.Parse("2002-02-15"), 175, Pie.DERECHO, 18000000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("10", "André Ayew", DateTime.Parse("1989-12-17"), 176, Pie.IZQUIERDO, 2500000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("15", "Joseph Paintsil", DateTime.Parse("1998-02-01"), 169, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("22", "Christopher Antwi-Adjei", DateTime.Parse("1994-02-07"), 174, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Daniel Afriyie", DateTime.Parse("2001-06-26"), 176, Pie.NO_DEFINIDO, 150000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("11", "Osman Bukari", DateTime.Parse("1998-12-13"), 17, Pie.AMBIDIESTRO, 3000000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("19", "Yaw Yeboah", DateTime.Parse("1997-03-28"), 175, Pie.IZQUIERDO, 1800000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Braydon Manu", DateTime.Parse("1997-03-28"), 17, Pie.AMBIDIESTRO, 550000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("9", "Jordan Ayew", DateTime.Parse("1991-09-11"), 182, Pie.DERECHO, 6000000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("13", "Felix Afena-Gyan", DateTime.Parse("2003-01-19"), 175, Pie.DERECHO, 6000000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("15", "Antoine Semenyo", DateTime.Parse("2000-01-07"), 178, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Benjamin Tetteh", DateTime.Parse("1997-07-10"), 193, Pie.DERECHO, 2300000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Ransford-Yeboah Königsdörffer", DateTime.Parse("2001-09-13"), 183, Pie.DERECHO, 1300000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("17", "Kwasi Wriedt", DateTime.Parse("1994-07-10"), 188, Pie.IZQUIERDO, 900000, Moneda.EUROS, Pais.GetPais("Ghana"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("16", "Edouard Mendy", DateTime.Parse("1992-03-01"), 194, Pie.DERECHO, 32000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Alfred Gomis", DateTime.Parse("1993-09-05"), 196, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Seny Dieng", DateTime.Parse("1994-11-23"), 193, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("3", "Kalidou Koulibaly", DateTime.Parse("1991-06-20"), 186, Pie.DERECHO, 35000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("22", "Abdou Diallo", DateTime.Parse("1996-05-04"), 187, Pie.IZQUIERDO, 18000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Pape Abou Cissé", DateTime.Parse("1995-09-14"), 198, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("14", "Abdoulaye Seck", DateTime.Parse("1992-06-04"), 192, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("12", "Fodé Ballo-Touré", DateTime.Parse("1997-01-03"), 182, Pie.IZQUIERDO, 3500000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("2", "Saliou Ciss", DateTime.Parse("1989-09-15"), 174, Pie.IZQUIERDO, 400000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("12", "Youssouf Sabaly", DateTime.Parse("1993-03-05"), 173, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("2", "Alpha Diounkou", DateTime.Parse("2001-10-10"), 184, Pie.DERECHO, 300000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("26", "Pape Gueye", DateTime.Parse("1999-01-24"), 183, Pie.IZQUIERDO, 12000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("6", "Nampalys Mendy", DateTime.Parse("1992-06-23"), 167, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("8", "Cheikhou Kouyaté", DateTime.Parse("1989-12-21"), 189, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("25", "Mamadou Loum", DateTime.Parse("1996-12-30"), 188, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("17", "Pape Matar Sarr", DateTime.Parse("2002-09-14"), 184, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("5", "Idrissa Gueye", DateTime.Parse("1989-09-26"), 174, Pie.DERECHO, 12000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("24", "Moustapha Name", DateTime.Parse("1995-05-05"), 185, Pie.AMBIDIESTRO, 2000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Iliman Ndiaye", DateTime.Parse("2000-03-06"), 18, Pie.NO_DEFINIDO, 1500000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("10", "Sadio Mané", DateTime.Parse("1992-04-10"), 174, Pie.DERECHO, 70000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("18", "Ismaïla Sarr", DateTime.Parse("1998-02-25"), 185, Pie.DERECHO, 27000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Demba Seck", DateTime.Parse("2001-02-10"), 19, Pie.IZQUIERDO, 3000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("9", "Boulaye Dia", DateTime.Parse("1996-11-16"), 18, Pie.DERECHO, 12000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("11", "Habib Diallo", DateTime.Parse("1995-06-18"), 186, Pie.DERECHO, 12000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("19", "Famara Diédhiou", DateTime.Parse("1992-12-15"), 189, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("7", "Keita Baldé", DateTime.Parse("1995-03-08"), 181, Pie.AMBIDIESTRO, 3000000, Moneda.EUROS, Pais.GetPais("Senegal"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("22", "Diogo Costa", DateTime.Parse("1999-09-19"), 186, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("12", "Rui Silva", DateTime.Parse("1994-02-07"), 191, Pie.IZQUIERDO, 15000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Rui Patrício", DateTime.Parse("1988-02-15"), 19, Pie.IZQUIERDO, 6000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("5", "David Carmo", DateTime.Parse("1999-07-19"), 196, Pie.IZQUIERDO, 15000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Domingos Duarte", DateTime.Parse("1995-03-10"), 192, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("3", "Pepe", DateTime.Parse("1983-02-26"), 187, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("19", "Nuno Mendes", DateTime.Parse("2002-06-19"), 176, Pie.IZQUIERDO, 40000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("20", "João Cancelo ", DateTime.Parse("1994-05-27"), 182, Pie.DERECHO, 65000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("2", "Diogo Dalot", DateTime.Parse("1999-03-18"), 183, Pie.DERECHO, 20000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("18", "Rúben Neves", DateTime.Parse("1997-03-13"), 18, Pie.DERECHO, 40000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("6", "João Palhinha", DateTime.Parse("1995-07-09"), 19, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("14", "William Carvalho", DateTime.Parse("1992-04-07"), 187, Pie.DERECHO, 16000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("13", "Danilo Pereira", DateTime.Parse("1991-09-09"), 188, Pie.DERECHO, 14000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("23", "Matheus Nunes", DateTime.Parse("1998-08-27"), 183, Pie.DERECHO, 35000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("11", "Vitinha", DateTime.Parse("2000-02-13"), 172, Pie.DERECHO, 30000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("16", "Otávio", DateTime.Parse("1995-02-09"), 172, Pie.DERECHO, 30000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.INTERIOR_DERECHO));
            Jugador.AltaJugador(new Jugador("8", "Bruno Fernandes", DateTime.Parse("1994-09-08"), 179, Pie.DERECHO, 85000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("10", "Bernardo Silva", DateTime.Parse("1994-08-10"), 173, Pie.IZQUIERDO, 80000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("15", "Rafael Leão", DateTime.Parse("1999-06-10"), 188, Pie.DERECHO, 70000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("21", "Diogo Jota", DateTime.Parse("1996-12-04"), 178, Pie.DERECHO, 60000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("17", "Gonçalo Guedes", DateTime.Parse("1996-11-29"), 179, Pie.DERECHO, 40000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("7", "Ricardo Horta", DateTime.Parse("1994-09-15"), 173, Pie.DERECHO, 20000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("9", "André Silva", DateTime.Parse("1995-11-06"), 185, Pie.DERECHO, 32000000, Moneda.EUROS, Pais.GetPais("Portugal"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("1", "Wojciech Szczesny ", DateTime.Parse("1990-04-18"), 196, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("22", "Bartlomiej Dragowski", DateTime.Parse("1997-08-19"), 191, Pie.DERECHO, 6000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Kamil Grabara ", DateTime.Parse("1999-01-08"), 195, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("12", "Lukasz Skorupski", DateTime.Parse("1991-05-05"), 187, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("5", "Jan Bednarek", DateTime.Parse("1996-04-12"), 189, Pie.DERECHO, 22000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("3", "Mateusz Wieteska", DateTime.Parse("1997-02-11"), 187, Pie.DERECHO, 1300000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Marcin Kaminski", DateTime.Parse("1992-01-15"), 192, Pie.IZQUIERDO, 1000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("15", "Kamil Glik", DateTime.Parse("1988-02-03"), 19, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("19", "Tymoteusz Puchacz ", DateTime.Parse("1999-01-23"), 18, Pie.IZQUIERDO, 2300000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("13", "Kamil Pestka", DateTime.Parse("1998-08-22"), 189, Pie.IZQUIERDO, 900000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("2", "Matty Cash", DateTime.Parse("1997-08-07"), 185, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("4", "Tomasz Kedziora", DateTime.Parse("1994-06-11"), 184, Pie.DERECHO, 4500000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("18", "Bartosz Bereszynski", DateTime.Parse("1992-07-12"), 183, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("25", "Robert Gumny", DateTime.Parse("1998-06-04"), 182, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("10", "Grzegorz Krychowiak", DateTime.Parse("1990-01-29"), 187, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Krystian Bielik", DateTime.Parse("1998-01-04"), 189, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("4", "Jakub Kiwior", DateTime.Parse("2000-02-15"), 189, Pie.IZQUIERDO, 3000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("6", "Jacek Goralski", DateTime.Parse("1992-09-21"), 172, Pie.DERECHO, 1600000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("8", "Szymon Zurkowski ", DateTime.Parse("1997-09-25"), 185, Pie.DERECHO, 7000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("8", "Karol Linetty", DateTime.Parse("1995-02-02"), 176, Pie.DERECHO, 3500000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("14", "Mateusz Klich", DateTime.Parse("1990-06-13"), 183, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("17", "Damian Szymanski", DateTime.Parse("1995-06-16"), 182, Pie.DERECHO, 1800000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("21", "Nicola Zalewski ", DateTime.Parse("2002-01-23"), 175, Pie.AMBIDIESTRO, 12000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.INTERIOR_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("19", "Przemyslaw Frankowski", DateTime.Parse("1995-04-12"), 176, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.INTERIOR_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Patryk Kun", DateTime.Parse("1995-04-20"), 165, Pie.AMBIDIESTRO, 1200000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.INTERIOR_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("20", "Piotr Zielinski", DateTime.Parse("1994-05-20"), 18, Pie.AMBIDIESTRO, 40000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("17", "Sebastian Szymanski", DateTime.Parse("1999-05-10"), 174, Pie.IZQUIERDO, 14000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("2", "Jakub Kaminski", DateTime.Parse("2002-06-05"), 179, Pie.DERECHO, 10000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Kamil Józwiak", DateTime.Parse("1998-04-22"), 176, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Przemyslaw Placheta", DateTime.Parse("1998-03-23"), 178, Pie.IZQUIERDO, 1800000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("11", "Kamil Grosicki", DateTime.Parse("1988-06-08"), 18, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Konrad Michalak", DateTime.Parse("1997-09-19"), 176, Pie.DERECHO, 1700000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("9", "Robert Lewandowski", DateTime.Parse("1988-08-21"), 185, Pie.DERECHO, 45000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Arkadiusz Milik", DateTime.Parse("1994-02-28"), 186, Pie.IZQUIERDO, 16000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("23", "Krzysztof Piatek", DateTime.Parse("1995-07-01"), 183, Pie.DERECHO, 12000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("7", "Adam Buksa ", DateTime.Parse("1996-07-12"), 193, Pie.IZQUIERDO, 9000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("16", "Karol Swiderski", DateTime.Parse("1997-01-23"), 184, Pie.IZQUIERDO, 5000000, Moneda.EUROS, Pais.GetPais("Polonia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Bechir Ben Said", DateTime.Parse("1994-11-29"), 194, Pie.NO_DEFINIDO, 850000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("16", "Aymen Dahmen", DateTime.Parse("1997-01-28"), 188, Pie.DERECHO, 850000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Mohamed Sedki Debchi", DateTime.Parse("1999-10-28"), 195, Pie.DERECHO, 500000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("3", "Montassar Talbi", DateTime.Parse("1998-05-26"), 19, Pie.DERECHO, 1200000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("6", "Nader Ghandri", DateTime.Parse("1995-02-18"), 196, Pie.DERECHO, 650000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("24", "Alaa Ghram", DateTime.Parse("2001-07-24"), 0, Pie.DERECHO, 450000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("2", "Bilel Ifa", DateTime.Parse("1990-03-09"), 185, Pie.DERECHO, 250000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Adam Ben Lamin", DateTime.Parse("2001-06-02"), 184, Pie.DERECHO, 200000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Ali Abdi", DateTime.Parse("1993-12-20"), 183, Pie.IZQUIERDO, 1500000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("12", "Ali Maâloul", DateTime.Parse("1990-01-01"), 175, Pie.IZQUIERDO, 1500000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("21", "Rami Kaib", DateTime.Parse("1997-05-08"), 178, Pie.NO_DEFINIDO, 700000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("20", "Mohamed Dräger", DateTime.Parse("1996-06-25"), 181, Pie.DERECHO, 1300000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("8", "Anis Slimane", DateTime.Parse("2001-03-16"), 188, Pie.AMBIDIESTRO, 3500000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("14", "Aïssa Laïdouni", DateTime.Parse("1996-12-13"), 183, Pie.DERECHO, 3500000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("15", "Mohamed Ali Ben Romdhane", DateTime.Parse("1999-09-06"), 185, Pie.DERECHO, 2700000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("13", "Ferjani Sassi", DateTime.Parse("1992-03-18"), 185, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("10", "Hannibal Mejbri", DateTime.Parse("2003-01-21"), 184, Pie.DERECHO, 6000000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("18", "Firas Ben Larbi", DateTime.Parse("1996-05-27"), 171, Pie.IZQUIERDO, 3000000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("8", "Mootez Zaddem", DateTime.Parse("2001-01-05"), 185, Pie.DERECHO, 500000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("23", "Naïm Sliti", DateTime.Parse("1992-07-27"), 173, Pie.DERECHO, 7500000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("7", "Youssef Msakni", DateTime.Parse("1990-10-28"), 179, Pie.DERECHO, 1200000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Elias Achouri", DateTime.Parse("1999-02-10"), 177, Pie.DERECHO, 300000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("17", "Issam Jebali", DateTime.Parse("1991-12-25"), 186, Pie.AMBIDIESTRO, 500000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.MEDIAPUNTA));
            Jugador.AltaJugador(new Jugador("19", "Seifeddine Jaziri", DateTime.Parse("1993-02-12"), 18, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Taha Yassine Khenissi", DateTime.Parse("1992-01-06"), 18, Pie.DERECHO, 500000, Moneda.EUROS, Pais.GetPais("Túnez"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("1", "Bono", DateTime.Parse("1991-04-05"), 192, Pie.IZQUIERDO, 18000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("12", "Munir", DateTime.Parse("1989-05-10"), 19, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Anas Zniti", DateTime.Parse("1988-10-28"), 182, Pie.DERECHO, 1200000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("5", "Nayef Aguerd ", DateTime.Parse("1996-03-30"), 188, Pie.IZQUIERDO, 12000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("6", "Romain Saïss", DateTime.Parse("1990-03-26"), 188, Pie.IZQUIERDO, 8000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Achraf Dari", DateTime.Parse("1999-05-06"), 188, Pie.DERECHO, 1800000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("24", "Samy Mmaee", DateTime.Parse("1996-09-08"), 188, Pie.DERECHO, 1300000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Jawad El Yamiq", DateTime.Parse("1992-02-29"), 193, Pie.DERECHO, 1200000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("18", "Soufiane Chakla", DateTime.Parse("1993-09-02"), 188, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("3", "Adam Masina", DateTime.Parse("1994-01-02"), 191, Pie.IZQUIERDO, 3000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Yahia Attiyat Allah", DateTime.Parse("1995-03-02"), 176, Pie.IZQUIERDO, 1000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("2", "Achraf Hakimi", DateTime.Parse("1998-11-04"), 181, Pie.DERECHO, 65000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Noussair Mazraoui", DateTime.Parse("1997-11-14"), 183, Pie.DERECHO, 20000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("20", "Sofiane Alakouch", DateTime.Parse("1998-07-29"), 175, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Mohamed Chibi", DateTime.Parse("1993-01-21"), 179, Pie.DERECHO, 825000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("4", "Sofyan Amrabat", DateTime.Parse("1996-08-21"), 185, Pie.DERECHO, 10000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Yahya Jabrane", DateTime.Parse("1991-06-18"), 187, Pie.DERECHO, 1700000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("7", "Imrân Louza", DateTime.Parse("1999-05-01"), 178, Pie.IZQUIERDO, 9000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("8", "Azzedine Ounahi", DateTime.Parse("2000-04-19"), 182, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Adel Taarabt", DateTime.Parse("1989-05-24"), 178, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("11", "Fayçal Fajr", DateTime.Parse("1988-08-01"), 179, Pie.DERECHO, 1800000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Amine Harit", DateTime.Parse("1997-06-18"), 18, Pie.DERECHO, 10000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("15", "Selim Amallah", DateTime.Parse("1996-11-15"), 186, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("13", "Ilias Chair", DateTime.Parse("1997-10-30"), 172, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Aymen Barkok", DateTime.Parse("1998-05-21"), 189, Pie.DERECHO, 1800000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("28", "Tarik Tissoudali ", DateTime.Parse("1993-04-02"), 182, Pie.DERECHO, 7500000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Soufiane Rahimi", DateTime.Parse("1996-06-02"), 18, Pie.DERECHO, 4500000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Zakaria Aboukhlal", DateTime.Parse("2000-02-18"), 179, Pie.AMBIDIESTRO, 2000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("19", "Youssef En-Nesyri", DateTime.Parse("1997-06-01"), 189, Pie.IZQUIERDO, 25000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("10", "Munir El Haddadi", DateTime.Parse("1995-09-01"), 175, Pie.IZQUIERDO, 8000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("9", "Ayoub El Kaabi", DateTime.Parse("1993-06-25"), 182, Pie.IZQUIERDO, 5000000, Moneda.EUROS, Pais.GetPais("Marruecos"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("24", "André Onana", DateTime.Parse("1996-04-02"), 19, Pie.DERECHO, 12000000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("16", "Devis Epassy", DateTime.Parse("1993-02-02"), 189, Pie.DERECHO, 600000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("23", "Simon Omossola", DateTime.Parse("1998-05-05"), 189, Pie.DERECHO, 400000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("21", "Jean-Charles Castelletto", DateTime.Parse("1995-01-26"), 186, Pie.AMBIDIESTRO, 4000000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("5", "Michael Ngadeu", DateTime.Parse("1990-11-23"), 19, Pie.DERECHO, 3500000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Christopher Wooh", DateTime.Parse("2001-09-18"), 191, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Duplexe Tchamba", DateTime.Parse("1998-07-10"), 191, Pie.IZQUIERDO, 400000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("25", "Nouhou", DateTime.Parse("1997-06-23"), 178, Pie.NO_DEFINIDO, 2500000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("6", "Ambroise Oyongo", DateTime.Parse("1991-06-22"), 176, Pie.IZQUIERDO, 1800000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("17", "Olivier Mbaizo", DateTime.Parse("1997-08-15"), 178, Pie.NO_DEFINIDO, 1500000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("19", "Collins Fai", DateTime.Parse("1992-08-13"), 165, Pie.DERECHO, 900000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("8", "André Zambo Anguissa", DateTime.Parse("1995-11-16"), 184, Pie.DERECHO, 30000000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("18", "Martin Hongla", DateTime.Parse("1998-03-16"), 181, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("14", "Samuel Oum Gouet", DateTime.Parse("1997-12-14"), 185, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("8", "Gaël Ondoua", DateTime.Parse("1995-11-04"), 185, Pie.IZQUIERDO, 1000000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Olivier Ntcham", DateTime.Parse("1996-02-09"), 18, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("15", "Pierre Kunde", DateTime.Parse("1995-07-26"), 18, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("12", "Karl Toko Ekambi", DateTime.Parse("1992-09-14"), 185, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("3", "Nicolas Moumi Ngamaleu", DateTime.Parse("1994-07-09"), 181, Pie.DERECHO, 4700000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Georges-Kevin N'Koudou", DateTime.Parse("1995-02-13"), 172, Pie.DERECHO, 4200000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("10", "Vincent Aboubakar", DateTime.Parse("1992-01-22"), 184, Pie.DERECHO, 7000000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("20", "Ignatius Ganago", DateTime.Parse("1999-02-16"), 179, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("13", "Eric Maxim Choupo-Moting", DateTime.Parse("1989-03-23"), 191, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Léandre Tawamba", DateTime.Parse("1989-12-20"), 189, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("9", "Kévin Soni", DateTime.Parse("1998-04-17"), 183, Pie.IZQUIERDO, 800000, Moneda.EUROS, Pais.GetPais("Camerún"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("1", "Carlos Acevedo", DateTime.Parse("1996-04-19"), 185, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("México"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("12", "Rodolfo Cota", DateTime.Parse("1987-07-03"), 183, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("México"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("13", "David Ochoa", DateTime.Parse("2001-01-16"), 188, Pie.NO_DEFINIDO, 800000, Moneda.EUROS, Pais.GetPais("México"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("3", "Jesús Angulo", DateTime.Parse("1998-01-30"), 178, Pie.IZQUIERDO, 6000000, Moneda.EUROS, Pais.GetPais("México"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("15", "Israel Reyes", DateTime.Parse("2000-05-23"), 179, Pie.DERECHO, 3500000, Moneda.EUROS, Pais.GetPais("México"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Julio Domínguez", DateTime.Parse("1987-11-08"), 177, Pie.DERECHO, 1400000, Moneda.EUROS, Pais.GetPais("México"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("19", "Érick Aguirre", DateTime.Parse("1997-02-23"), 171, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("México"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("23", "Jesús Gallardo", DateTime.Parse("1994-08-15"), 176, Pie.IZQUIERDO, 3000000, Moneda.EUROS, Pais.GetPais("México"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("2", "Kevin Álvarez", DateTime.Parse("1999-01-15"), 176, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("México"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("5", "Julián Araujo", DateTime.Parse("2001-08-13"), 175, Pie.DERECHO, 4500000, Moneda.EUROS, Pais.GetPais("México"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("18", "Luis Chávez", DateTime.Parse("1996-01-15"), 178, Pie.IZQUIERDO, 5000000, Moneda.EUROS, Pais.GetPais("México"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("18", "Erik Lira", DateTime.Parse("2000-05-08"), 172, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("México"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("6", "Érick Sánchez", DateTime.Parse("1999-09-27"), 167, Pie.DERECHO, 7000000, Moneda.EUROS, Pais.GetPais("México"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("7", "Luis Romo", DateTime.Parse("1995-06-05"), 184, Pie.DERECHO, 7000000, Moneda.EUROS, Pais.GetPais("México"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("16", "Fernando Beltrán", DateTime.Parse("1998-05-08"), 168, Pie.DERECHO, 4500000, Moneda.EUROS, Pais.GetPais("México"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("10", "Orbelín Pineda", DateTime.Parse("1996-03-24"), 169, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("México"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("8", "Sebastián Córdova", DateTime.Parse("1997-06-12"), 174, Pie.NO_DEFINIDO, 5000000, Moneda.EUROS, Pais.GetPais("México"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("20", "Rodolfo Pizarro", DateTime.Parse("1994-02-15"), 175, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("México"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("17", "Marcelo Flores", DateTime.Parse("2003-10-01"), 164, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("México"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("22", "Uriel Antuna", DateTime.Parse("1997-08-21"), 174, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("México"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("11", "Diego Lainez", DateTime.Parse("2000-06-09"), 168, Pie.IZQUIERDO, 2500000, Moneda.EUROS, Pais.GetPais("México"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("9", "Santiago Giménez", DateTime.Parse("2001-04-18"), 183, Pie.IZQUIERDO, 4000000, Moneda.EUROS, Pais.GetPais("México"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("21", "Henry Martín", DateTime.Parse("1992-11-18"), 177, Pie.DERECHO, 3500000, Moneda.EUROS, Pais.GetPais("México"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("1", "Matt Turner", DateTime.Parse("1994-06-24"), 191, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Sean Johnson", DateTime.Parse("1989-05-31"), 19, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("18", "Ethan Horvath", DateTime.Parse("1995-06-09"), 195, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("20", "Cameron Carter-Vickers", DateTime.Parse("1997-12-31"), 183, Pie.DERECHO, 7000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("3", "Walker Zimmerman", DateTime.Parse("1993-05-19"), 19, Pie.DERECHO, 3500000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("12", "Erik Palmer-Brown", DateTime.Parse("1997-04-24"), 186, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("15", "Aaron Long", DateTime.Parse("1992-10-12"), 186, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("5", "Antonee Robinson", DateTime.Parse("1997-08-08"), 183, Pie.IZQUIERDO, 8000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("24", "George Bello", DateTime.Parse("2002-01-22"), 17, Pie.IZQUIERDO, 3000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("29", "Joe Scally", DateTime.Parse("2002-12-31"), 184, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("22", "Reggie Cannon", DateTime.Parse("1998-06-11"), 18, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("2", "DeAndre Yedlin", DateTime.Parse("1993-07-09"), 173, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("4", "Tyler Adams", DateTime.Parse("1999-02-14"), 175, Pie.DERECHO, 17000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("23", "Kellyn Acosta", DateTime.Parse("1995-07-24"), 177, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("8", "Weston McKennie ", DateTime.Parse("1998-08-28"), 177, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("6", "Yunus Musah", DateTime.Parse("2002-11-29"), 178, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("16", "Cristian Roldán", DateTime.Parse("1995-06-03"), 173, Pie.NO_DEFINIDO, 5500000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("14", "Luca de la Torre", DateTime.Parse("1998-05-23"), 177, Pie.DERECHO, 850000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("11", "Brenden Aaronson", DateTime.Parse("2000-10-22"), 178, Pie.DERECHO, 25000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("17", "Malik Tillman", DateTime.Parse("2002-05-28"), 187, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("13", "Jordan Morris", DateTime.Parse("1994-10-26"), 181, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("10", "Christian Pulisic", DateTime.Parse("1998-09-18"), 177, Pie.DERECHO, 42000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("7", "Paul Arriola", DateTime.Parse("1995-02-05"), 167, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("21", "Timothy Weah", DateTime.Parse("2000-02-22"), 185, Pie.DERECHO, 12000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("9", "Jesús Ferreira", DateTime.Parse("2000-12-24"), 173, Pie.NO_DEFINIDO, 6000000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("19", "Haji Wright", DateTime.Parse("1998-03-27"), 193, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Estados Unidos"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("12", "Danny Ward", DateTime.Parse("1993-06-22"), 189, Pie.DERECHO, 6000000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("21", "Adam Davies", DateTime.Parse("1992-07-17"), 185, Pie.DERECHO, 700000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("1", "Wayne Hennessey", DateTime.Parse("1987-01-24"), 197, Pie.DERECHO, 500000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Tom King", DateTime.Parse("1995-03-09"), 194, Pie.DERECHO, 200000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("15", "Ethan Ampadu", DateTime.Parse("2000-09-14"), 183, Pie.DERECHO, 13000000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("6", "Joe Rodon", DateTime.Parse("1997-10-22"), 192, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("5", "Chris Mepham", DateTime.Parse("1997-11-05"), 19, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Oliver Denham", DateTime.Parse("2002-05-04"), 182, Pie.DERECHO, 0, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("4", "Ben Davies", DateTime.Parse("1993-04-24"), 181, Pie.IZQUIERDO, 20000000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("17", "Rhys Norrington-Davies", DateTime.Parse("1999-04-22"), 181, Pie.IZQUIERDO, 1500000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("3", "Neco Williams", DateTime.Parse("2001-04-13"), 177, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("14", "Connor Roberts", DateTime.Parse("1995-09-23"), 175, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("2", "Chris Gunter", DateTime.Parse("1989-07-21"), 18, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Matt Smith", DateTime.Parse("1999-11-22"), 175, Pie.DERECHO, 450000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("10", "Aaron Ramsey", DateTime.Parse("1990-12-26"), 182, Pie.DERECHO, 3000000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("7", "Joe Allen", DateTime.Parse("1990-03-14"), 168, Pie.DERECHO, 1200000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Dylan Levitt", DateTime.Parse("2000-11-17"), 18, Pie.DERECHO, 650000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("16", "Joe Morrell ", DateTime.Parse("1997-01-03"), 185, Pie.DERECHO, 400000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Wes Burns", DateTime.Parse("1994-11-23"), 173, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.INTERIOR_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Rubin Colwill", DateTime.Parse("2002-04-27"), 189, Pie.NO_DEFINIDO, 1500000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("18", "Jonathan Williams", DateTime.Parse("1993-10-09"), 168, Pie.IZQUIERDO, 800000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("20", "Daniel James", DateTime.Parse("1997-11-10"), 17, Pie.DERECHO, 18000000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("8", "Harry Wilson ", DateTime.Parse("1997-03-22"), 173, Pie.IZQUIERDO, 17000000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("23", "Rabbi Matondo", DateTime.Parse("2000-09-09"), 175, Pie.DERECHO, 4000000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("11", "Gareth Bale ", DateTime.Parse("1989-07-16"), 185, Pie.IZQUIERDO, 3000000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("22", "Sorba Thomas", DateTime.Parse("1999-01-25"), 185, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("9", "Brennan Johnson", DateTime.Parse("2001-05-23"), 179, Pie.DERECHO, 15000000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.MEDIAPUNTA));
            Jugador.AltaJugador(new Jugador("13", "Kieffer Moore", DateTime.Parse("1992-08-08"), 195, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("19", "Mark Harris", DateTime.Parse("1998-12-29"), 182, Pie.DERECHO, 1200000, Moneda.EUROS, Pais.GetPais("Gales"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("1", "Mathew Ryan", DateTime.Parse("1992-04-08"), 184, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("12", "Andrew Redmayne", DateTime.Parse("1989-01-13"), 194, Pie.NO_DEFINIDO, 700000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("18", "Danny Vukovic", DateTime.Parse("1985-03-27"), 187, Pie.DERECHO, 150000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("19", "Harry Souttar ", DateTime.Parse("1998-10-22"), 201, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("2", "Milos Degenek", DateTime.Parse("1994-04-28"), 187, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Bailey Wright", DateTime.Parse("1992-07-28"), 186, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("20", "Trent Sainsbury", DateTime.Parse("1992-01-05"), 184, Pie.DERECHO, 750000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("20", "Kye Rowles", DateTime.Parse("1998-06-24"), 183, Pie.IZQUIERDO, 600000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("23", "Gianni Stensness ", DateTime.Parse("1999-02-07"), 185, Pie.DERECHO, 600000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("16", "Aziz Behich", DateTime.Parse("1990-12-16"), 17, Pie.IZQUIERDO, 775000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Jason Davidson", DateTime.Parse("1991-06-29"), 182, Pie.IZQUIERDO, 500000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Joel King", DateTime.Parse("2000-10-30"), 18, Pie.IZQUIERDO, 500000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("2", "Nathaniel Atkinson", DateTime.Parse("1999-06-13"), 181, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("5", "Fran Karacic", DateTime.Parse("1996-05-12"), 185, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("4", "Rhyan Grant", DateTime.Parse("1991-02-26"), 174, Pie.DERECHO, 750000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("8", "James Jeggo", DateTime.Parse("1992-02-12"), 178, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("8", "Connor Metcalfe", DateTime.Parse("1999-11-05"), 183, Pie.IZQUIERDO, 800000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Kenny Dougall", DateTime.Parse("1993-05-07"), 182, Pie.DERECHO, 600000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("13", "Aaron Mooy", DateTime.Parse("1990-09-15"), 174, Pie.DERECHO, 5000000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("10", "Ajdin Hrustic", DateTime.Parse("1996-07-05"), 183, Pie.IZQUIERDO, 3000000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Riley McGree", DateTime.Parse("1998-11-02"), 178, Pie.IZQUIERDO, 2500000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("22", "Jackson Irvine", DateTime.Parse("1993-03-07"), 189, Pie.DERECHO, 2000000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("23", "Tom Rogic", DateTime.Parse("1992-12-16"), 188, Pie.DERECHO, 1700000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("17", "Denis Genreau", DateTime.Parse("1999-05-21"), 175, Pie.DERECHO, 1200000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Awer Mabil", DateTime.Parse("1995-09-15"), 179, Pie.DERECHO, 1800000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("19", "Craig Goodwin", DateTime.Parse("1991-12-16"), 18, Pie.IZQUIERDO, 1200000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("7", "Mathew Leckie", DateTime.Parse("1991-02-04"), 181, Pie.DERECHO, 1000000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Ben Folami", DateTime.Parse("1999-06-08"), 18, Pie.AMBIDIESTRO, 500000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("6", "Martin Boyle", DateTime.Parse("1993-04-25"), 172, Pie.DERECHO, 2500000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("21", "Marco Tilio", DateTime.Parse("2001-08-23"), 17, Pie.IZQUIERDO, 900000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Nick D'Agostino", DateTime.Parse("1998-02-25"), 175, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("9", "Jamie Maclaren", DateTime.Parse("1993-07-29"), 179, Pie.DERECHO, 1500000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("NO_DEFINIDO", "Adam Taggart", DateTime.Parse("1993-06-02"), 177, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("15", "Mitchell Duke", DateTime.Parse("1991-01-18"), 186, Pie.DERECHO, 700000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("14", "Bruno Fornaroli ", DateTime.Parse("1987-09-07"), 174, Pie.DERECHO, 600000, Moneda.EUROS, Pais.GetPais("Australia"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("1", "Keylor Navas", DateTime.Parse("1986-12-15"), 185, Pie.DERECHO, 8000000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("18", "Aaron Cruz", DateTime.Parse("1991-05-25"), 187, Pie.DERECHO, 275000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("23", "Leonel Moreira", DateTime.Parse("1990-04-02"), 176, Pie.DERECHO, 275000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.PORTERO));
            Jugador.AltaJugador(new Jugador("3", "Juan Pablo Vargas", DateTime.Parse("1995-06-06"), 192, Pie.IZQUIERDO, 1000000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("15", "Francisco Calvo", DateTime.Parse("1992-07-08"), 18, Pie.IZQUIERDO, 1000000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("6", "Óscar Duarte", DateTime.Parse("1989-06-03"), 186, Pie.DERECHO, 800000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("19", "Kendall Waston", DateTime.Parse("1988-01-01"), 196, Pie.DERECHO, 225000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.DEFENSA_CENTRAL));
            Jugador.AltaJugador(new Jugador("16", "Ian Lawrence", DateTime.Parse("2002-05-28"), 179, Pie.IZQUIERDO, 250000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("8", "Bryan Oviedo", DateTime.Parse("1990-02-18"), 172, Pie.IZQUIERDO, 200000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.LATERAL_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("4", "Keysher Fuller ", DateTime.Parse("1994-07-12"), 183, Pie.DERECHO, 225000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("22", "Carlos Martínez", DateTime.Parse("1999-03-30"), 176, Pie.DERECHO, 225000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.LATERAL_DERECHO));
            Jugador.AltaJugador(new Jugador("14", "Orlando Galo", DateTime.Parse("2000-08-11"), 176, Pie.DERECHO, 300000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("20", "Daniel Chacón", DateTime.Parse("2001-04-11"), 183, Pie.DERECHO, 300000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("17", "Yeltsin Tejeda", DateTime.Parse("1992-03-17"), 179, Pie.DERECHO, 275000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.PIVOTE));
            Jugador.AltaJugador(new Jugador("5", "Celso Borges", DateTime.Parse("1988-05-27"), 182, Pie.DERECHO, 225000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.MEDIOCENTRO));
            Jugador.AltaJugador(new Jugador("13", "Gerson Torres", DateTime.Parse("1997-08-28"), 176, Pie.IZQUIERDO, 325000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.INTERIOR_DERECHO));
            Jugador.AltaJugador(new Jugador("21", "Brandon Aguilera", DateTime.Parse("2003-06-28"), 181, Pie.IZQUIERDO, 325000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("10", "Bryan Ruiz", DateTime.Parse("1985-08-18"), 187, Pie.IZQUIERDO, 200000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.MEDIOCENTRO_OFENSIVO));
            Jugador.AltaJugador(new Jugador("9", "Jewison Bennette", DateTime.Parse("2004-06-15"), 175, Pie.IZQUIERDO, 275000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.EXTREMO_IZQUIERDO));
            Jugador.AltaJugador(new Jugador("12", "Joel Campbell", DateTime.Parse("1992-06-26"), 178, Pie.IZQUIERDO, 2500000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("2", "Carlos Mora", DateTime.Parse("2001-03-18"), 178, Pie.DERECHO, 275000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.EXTREMO_DERECHO));
            Jugador.AltaJugador(new Jugador("7", "Anthony Contreras", DateTime.Parse("2000-01-29"), 18, Pie.DERECHO, 350000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.DELANTERO_CENTRO));
            Jugador.AltaJugador(new Jugador("11", "Johan Venegas", DateTime.Parse("1988-11-27"), 183, Pie.DERECHO, 325000, Moneda.EUROS, Pais.GetPais("Costa Rica"), Posicion.DELANTERO_CENTRO));
        }
        public static void PreLoadPaises()
        {
            Pais.AltaPais(new Pais("Catar", "QAT"));
            Pais.AltaPais(new Pais("Alemania", "DEU"));
            Pais.AltaPais(new Pais("Dinamarca", "DNK"));
            Pais.AltaPais(new Pais("Brasil", "BRA"));
            Pais.AltaPais(new Pais("Francia", "FRA"));
            Pais.AltaPais(new Pais("Bélgica", "BEL"));
            Pais.AltaPais(new Pais("Croacia", "HRV"));
            Pais.AltaPais(new Pais("España", "ESP"));
            Pais.AltaPais(new Pais("Serbia", "SRB"));
            Pais.AltaPais(new Pais("Inglaterra", "GBR"));
            Pais.AltaPais(new Pais("Suiza", "CHE"));
            Pais.AltaPais(new Pais("Países Bajos", "NLD"));
            Pais.AltaPais(new Pais("Argentina", "ARG"));
            Pais.AltaPais(new Pais("Irán", "IRN"));
            Pais.AltaPais(new Pais("Corea del Sur", "KOR"));
            Pais.AltaPais(new Pais("Japón", "JPN"));
            Pais.AltaPais(new Pais("Arabia Saudita", "SAU"));
            Pais.AltaPais(new Pais("Ecuador", "ECU"));
            Pais.AltaPais(new Pais("Uruguay", "URY"));
            Pais.AltaPais(new Pais("Canadá", "CAN"));
            Pais.AltaPais(new Pais("Ghana", "GHA"));
            Pais.AltaPais(new Pais("Senegal", "SEN"));
            Pais.AltaPais(new Pais("Marruecos", "MAR"));
            Pais.AltaPais(new Pais("Túnez", "TUN"));
            Pais.AltaPais(new Pais("Portugal", "PRT"));
            Pais.AltaPais(new Pais("Polonia", "POL"));
            Pais.AltaPais(new Pais("Camerún", "CMR"));
            Pais.AltaPais(new Pais("México", "MEX"));
            Pais.AltaPais(new Pais("Estados Unidos", "USA"));
            Pais.AltaPais(new Pais("Gales", "WLS"));
            Pais.AltaPais(new Pais("Australia", "AUS"));
            Pais.AltaPais(new Pais("Costa Rica", "CRI"));

            Administradora.Instance.Paises.Sort();
        }
        public static void PreLoadPeriodistas()
        {
            Periodista.AltaPeriodista(new Periodista("Fabricio", "Barrios", "fabriciobarrios@gmail.com", "nosoyreal1"));
            Periodista.AltaPeriodista(new Periodista("Federico", "Barrios", "federicobarrios@gmail.com", "nosoyreal2"));
            Periodista.AltaPeriodista(new Periodista("Fernando", "Barrios", "fernandobarrios@gmail.com", "nosoyreal3"));

            Operador.AltaOperador(new Operador("Francisco", "Barrios", "franciscobarrios@gmail.com", "nosoyreal4", RandomDate()));
            Operador.AltaOperador(new Operador("Franco", "Barrios", "francobarrios@gmail.com", "nosoyreal5", RandomDate()));
        }

        public static void PreLoadPartidos()
        {
            //Partidos de fase de grupos
            //Grupo A - Ganadores Selecciones[0] y Selecciones[3]
            FaseGrupos.AltaPartido(new FaseGrupos(Administradora.Instance.Selecciones[8], Administradora.Instance.Selecciones[0], RandomDate(), Grupo.A));
            FaseGrupos.AltaPartido(new FaseGrupos(Administradora.Instance.Selecciones[8], Administradora.Instance.Selecciones[12], RandomDate(), Grupo.A));
            FaseGrupos.AltaPartido(new FaseGrupos(Administradora.Instance.Selecciones[8], Administradora.Instance.Selecciones[5], RandomDate(), Grupo.A));
            FaseGrupos.AltaPartido(new FaseGrupos(Administradora.Instance.Selecciones[0], Administradora.Instance.Selecciones[12], RandomDate(), Grupo.A));
            FaseGrupos.AltaPartido(new FaseGrupos(Administradora.Instance.Selecciones[0], Administradora.Instance.Selecciones[5], RandomDate(), Grupo.A));
            FaseGrupos.AltaPartido(new FaseGrupos(Administradora.Instance.Selecciones[12], Administradora.Instance.Selecciones[5], RandomDate(), Grupo.A));
            //Grupo B - Ganadores Selecciones[4] y Selecciones[7]
            FaseGrupos.AltaPartido(new FaseGrupos(Administradora.Instance.Selecciones[16], Administradora.Instance.Selecciones[4], RandomDate(), Grupo.B));
            FaseGrupos.AltaPartido(new FaseGrupos(Administradora.Instance.Selecciones[16], Administradora.Instance.Selecciones[11], RandomDate(), Grupo.B));
            FaseGrupos.AltaPartido(new FaseGrupos(Administradora.Instance.Selecciones[16], Administradora.Instance.Selecciones[14], RandomDate(), Grupo.B));
            FaseGrupos.AltaPartido(new FaseGrupos(Administradora.Instance.Selecciones[4], Administradora.Instance.Selecciones[11], RandomDate(), Grupo.B));
            FaseGrupos.AltaPartido(new FaseGrupos(Administradora.Instance.Selecciones[4], Administradora.Instance.Selecciones[14], RandomDate(), Grupo.B));
            FaseGrupos.AltaPartido(new FaseGrupos(Administradora.Instance.Selecciones[11], Administradora.Instance.Selecciones[14], RandomDate(), Grupo.B));
            //Partidos de eliminatorias
            FaseEliminatoria.AltaPartido(new FaseEliminatoria(Administradora.Instance.Selecciones[8], Administradora.Instance.Selecciones[14], RandomDate(), Etapa.OCTAVOS));
            FaseEliminatoria.AltaPartido(new FaseEliminatoria(Administradora.Instance.Selecciones[16], Administradora.Instance.Selecciones[5], RandomDate(), Etapa.OCTAVOS));
        }
        
        public static void PreLoadIncidentes()
        {
            //Catar (Local) vs Alemania (Visitante)
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[0], Administradora.Instance.Jugadores[59], TipoIncidente.TARJETA_AMARILLA, 7));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[0], Administradora.Instance.Jugadores[79], TipoIncidente.TARJETA_AMARILLA, 22));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[0], Administradora.Instance.Jugadores[73], TipoIncidente.GOL, 26));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[0], Administradora.Instance.Jugadores[32], TipoIncidente.GOL, 44));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[0], Administradora.Instance.Jugadores[36], TipoIncidente.GOL, 87));
            //Catar (Local) vs Dinamarca (Visitante)
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[31], TipoIncidente.TARJETA_AMARILLA, 41));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[83], TipoIncidente.TARJETA_ROJA, 63));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[90], TipoIncidente.TARJETA_ROJA, 77));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[98], TipoIncidente.TARJETA_AMARILLA, 79));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[88], TipoIncidente.GOL, 80));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[32], TipoIncidente.GOL, 81));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[33], TipoIncidente.GOL, 85));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[32], TipoIncidente.GOL, 87));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[1], Administradora.Instance.Jugadores[32], TipoIncidente.GOL, 88));
            //Catar (Local) vs Brasil (Visitante)
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[2], Administradora.Instance.Jugadores[126], TipoIncidente.TARJETA_AMARILLA, 15));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[2], Administradora.Instance.Jugadores[124], TipoIncidente.GOL, 76));
            //Alemania (Local) vs Dinamarca (Visitante)
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[3], Administradora.Instance.Jugadores[66], TipoIncidente.TARJETA_AMARILLA, 55));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[3], Administradora.Instance.Jugadores[66], TipoIncidente.TARJETA_AMARILLA, 55));
            //Alemania (Local) vs Brasil (Visitante)
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[4], Administradora.Instance.Jugadores[120], TipoIncidente.GOL, 12));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[4], Administradora.Instance.Jugadores[124], TipoIncidente.GOL, 16));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[4], Administradora.Instance.Jugadores[120], TipoIncidente.GOL, 33));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[4], Administradora.Instance.Jugadores[118], TipoIncidente.TARJETA_ROJA, 61));
            //Dinamarca (Local) vs Brasil (Visitante)
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[5], Administradora.Instance.Jugadores[88], TipoIncidente.TARJETA_AMARILLA, 2));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[5], Administradora.Instance.Jugadores[120], TipoIncidente.GOL, 44));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[5], Administradora.Instance.Jugadores[121], TipoIncidente.GOL, 63));
            //Francia (Local) vs Bélgica (Visitante)
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[6], Administradora.Instance.Jugadores[132], TipoIncidente.TARJETA_AMARILLA, 12));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[6], Administradora.Instance.Jugadores[133], TipoIncidente.TARJETA_AMARILLA, 17));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[6], Administradora.Instance.Jugadores[151], TipoIncidente.GOL, 33));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[6], Administradora.Instance.Jugadores[150], TipoIncidente.GOL, 43));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[6], Administradora.Instance.Jugadores[154], TipoIncidente.GOL, 59));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[6], Administradora.Instance.Jugadores[160], TipoIncidente.GOL, 88));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[6], Administradora.Instance.Jugadores[160], TipoIncidente.TARJETA_ROJA, 89));
            //Francia (Local) vs Croacia (Visitante)
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[7], Administradora.Instance.Jugadores[154], TipoIncidente.GOL, 11));
            //Francia (Local) vs España (Visitante)
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[8], Administradora.Instance.Jugadores[115], TipoIncidente.GOL, 1));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[8], Administradora.Instance.Jugadores[150], TipoIncidente.GOL, 45));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[8], Administradora.Instance.Jugadores[150], TipoIncidente.GOL, 23));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[8], Administradora.Instance.Jugadores[151], TipoIncidente.GOL, 70));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[8], Administradora.Instance.Jugadores[124], TipoIncidente.GOL, 74));
            //Bélgica (Local) vs Croacia (Visitante)
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[9], Administradora.Instance.Jugadores[157], TipoIncidente.TARJETA_AMARILLA, 37));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[9], Administradora.Instance.Jugadores[159], TipoIncidente.GOL, 41));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[9], Administradora.Instance.Jugadores[190], TipoIncidente.GOL, 44));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[9], Administradora.Instance.Jugadores[190], TipoIncidente.GOL, 63));
            //Bélgica (Local) vs España (Visitante)
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[10], Administradora.Instance.Jugadores[224], TipoIncidente.GOL, 79));
            //Croacia (Local) vs España (Visitante)
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[11], Administradora.Instance.Jugadores[182], TipoIncidente.TARJETA_AMARILLA, 12));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[11], Administradora.Instance.Jugadores[224], TipoIncidente.GOL, 53));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[11], Administradora.Instance.Jugadores[225], TipoIncidente.GOL, 77));
            //Octavos
            //Croacia (Local) vs España (Visitante)
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[12], Administradora.Instance.Jugadores[190], TipoIncidente.GOL, 86));
            //Francia (Local) vs Brasil (Visitante)
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[13], Administradora.Instance.Jugadores[120], TipoIncidente.GOL, 7));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[13], Administradora.Instance.Jugadores[120], TipoIncidente.GOL, 17));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[13], Administradora.Instance.Jugadores[120], TipoIncidente.GOL, 23));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[13], Administradora.Instance.Jugadores[150], TipoIncidente.GOL, 37));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[13], Administradora.Instance.Jugadores[120], TipoIncidente.GOL, 53));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[13], Administradora.Instance.Jugadores[120], TipoIncidente.TARJETA_AMARILLA, 44));
            Incidente.AltaIncidente(new Incidente(Administradora.Instance.Partidos[13], Administradora.Instance.Jugadores[120], TipoIncidente.TARJETA_AMARILLA, 81));
        }
        
        public static void PrecargaSelecciones()
        {
            //Contamos con países y jugadores, la seleccion debe armar para cada pais una seleccion.
            foreach (Pais pais in Administradora.Instance.Paises)
            {
                //Se crea una seleccion por cada país en la lista.
                Seleccion nuevaSeleccion = new Seleccion(pais);
                List<Jugador> jugadores = Seleccion.ListarJugadores(pais);
                //Recorro los jugadores de dicha selección.
                nuevaSeleccion.Jugadores.AddRange(jugadores);
                //foreach (Jugador j in jugadores) nuevaSeleccion.Jugadores.Add(j);
                Seleccion.AltaSeleccion(nuevaSeleccion);
            }
        }

        public static void PreLoadResenas()
        {
            //Resena.CrearResena(Administradora.Instance.Usuarios[0], "");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Jugador
    {
        //Atributos
        private static int autoIncrementId;
        private int id;
        private string numeroCamiseta;
        private string nombre;
        private DateTime fechaNacimiento;
        private int alturaCM;
        private Pie pieHabil;
        private int valorMercado;
        private Moneda moneda;
        private Pais pais;
        private Posicion posicion;

        //Constructores
        public Jugador() 
        {
            this.id = ++autoIncrementId;
        }

        public Jugador(string numeroCamiseta, string nombre, DateTime fechaNacimiento, 
            int alturaCM, Pie pieHabil, int valorMercado, Moneda moneda, Pais pais, Posicion posicion)
        {
            this.id = ++autoIncrementId;
            this.numeroCamiseta = numeroCamiseta;
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
            this.alturaCM = alturaCM;
            this.pieHabil = pieHabil;
            this.valorMercado = valorMercado;
            this.moneda = moneda;
            this.pais = pais;
            this.posicion = posicion;
        }

        /// <summary>
        /// Genera el alta del Jugador en el sistema.
        /// </summary>
        public static void AltaJugador(Jugador jugador)
        {
           if (jugador.ValidarNombre() && jugador.ValidarNumeroCamiseta() && jugador.ValidarFechaNacimiento())
            {
                if (jugador.ValidarAlturaCM() && !jugador.Pais.EsPaisVacio() && jugador.Posicion.ToString().Length > 0 && jugador.ValorMercado > 0)
                    Administradora.Instance.Jugadores.Add(jugador);
            }
        }
        /// <summary>
        /// Retorna el listado de jugadores con al menos una expulsión.
        /// </summary>
        public List<Jugador> GetJugadoresExpulsados(Jugador jugador)
        {
            /*
             * FALTA IMPLEMENTAR EL ORDENADO PARA EL RETORNO. SEGUN LA LETRA, SE DEBE RETORNAR DE DOS FORMAS DIFERENTES. 
             */

            List<Jugador> jugadorIncidentes = new List<Jugador>();

            foreach (Incidente incidente in Administradora.Instance.Incidentes)
            {
                if (incidente.Jugador.Equals(jugador) && Incidente.EsTarjetaRoja(incidente)) jugadorIncidentes.Add(jugador);
            }
            return jugadorIncidentes;
        }
        public bool ValidarNombre()
        {
            return (Utils.ValidLength(this.Nombre, 0));
        }
        public bool ValidarNumeroCamiseta()
        {
            return (Utils.ValidLength(this.NumeroCamiseta, 0));
        }
        public bool ValidarFechaNacimiento()
        {
            //Date example
            //DateTime.Parse("1992-09-02");
            //DateTime thisDate1 = new DateTime(2011, 6, 10); thisDate1.ToString("MMMM dd, yyyy");
            return (DateTime.Now.ToString("yyyy-MM-dd").Length == this.FechaNacimiento.ToString("dd-MM-yyyy").Length);
        }
        /// <summary>
        /// Valida que la altura del jugador sea valida.
        /// </summary>
        public bool ValidarAlturaCM()
        {
            return (this.AlturaCM > 0);
        }
        /// <summary>
        /// Retorna el listado de jugadores que disputaron un determinado partido.
        /// </summary>
        public static List<Jugador> TotalJugadoresPartidos(Partido partido)
        {
            List<Jugador> jugadores = new List<Jugador>();
            //Agrego todos los jugadores del equipo local, más los del equipo visitante.
            jugadores.AddRange(partido.Local.Jugadores);
            jugadores.AddRange(partido.Visitante.Jugadores);

            return jugadores;
        }
        /// <summary>
        /// Retorna la categoria correspondiente al valor de mercado del jugador.
        /// </summary>
        public TipoCategoria GetCategoria()
        {
            return Categoria.AsignarCategoria(this);
        }

        //Getters && Setters
        public int Id
        {
            get { return this.id; }
        }
        public string Nombre
        {
            get { return this.nombre; }
        }
        public Posicion Posicion
        {
            get { return this.posicion; }
        }
        public string NumeroCamiseta
        {
            get { return this.numeroCamiseta; }
        }
        public DateTime FechaNacimiento
        {
            get { return this.fechaNacimiento; }
        }
        public int AlturaCM
        {
            get { return this.alturaCM; }
        }
        public Pie PieHabil
        {
            get { return this.pieHabil; }
        }
        public int ValorMercado
        {
            get { return this.valorMercado; }
        }
        public Moneda Moneda
        {
            get { return this.moneda; }
        }
        public Pais Pais
        {
            get { return this.pais; }
        }
    }
}

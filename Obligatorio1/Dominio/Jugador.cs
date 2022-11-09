using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Jugador : IComparable<Jugador>, IValidar
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
            this.nombre = nombre;
            this.fechaNacimiento = fechaNacimiento;
            this.numeroCamiseta = numeroCamiseta;
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
                if (jugador.Validar()) Administradora.Instance.Jugadores.Add(jugador);
        }
        /// <summary>
        /// Retorna el listado de jugadores con al menos una expulsión.
        /// </summary>
        public static List<Jugador> GetJugadoresExpulsados()
        {
            List<Jugador> jugadorIncidentes = new List<Jugador>();
            //Recorro todos los incidentes y valido si es una expulsión.
            foreach (Incidente incidente in Administradora.Instance.Incidentes)
            {
                if (Incidente.EsTarjetaRoja(incidente)) jugadorIncidentes.Add(incidente.Jugador);
            }
            //Ordeno la lista previo al retorno.
            jugadorIncidentes.Sort();
            return jugadorIncidentes;
        }
        /// <summary>
        /// Retorna un jugador según el Id especificado.
        /// </summary>
        public static Jugador GetJugador(int id = 0)
        {
            Jugador jugador = new Jugador();

            foreach (Jugador j in Administradora.Instance.Jugadores)
            {
                if (j.Id.ToString().Equals(id))
                {
                    jugador = j;
                    break;
                }
            }
            return jugador;
        }
        /// <summary>
        /// Retorna el objecto en formato string.
        /// </summary>
        public override string ToString() => ($"Nombre {this.Nombre} [{this.Pais.Codigo}]. Camiseta {this.NumeroCamiseta} - Posición {this.Posicion}");
        /// <summary>
        /// Retorna TRUE si el objeto es valido.
        /// </summary>
        public bool Validar() => (this.Nombre.Length > 0 && this.Nombre.IndexOf(" ") > -1 && this.NumeroCamiseta.Length > 0 && this.NumeroCamiseta.Length > 0
                && DateTime.Now.ToString("yyyy-MM-dd").Length == this.FechaNacimiento.ToString("dd-MM-yyyy").Length && this.AlturaCM > 0);
        /// <summary>
        /// Retorna el listado de jugadores que disputaron un determinado partido.
        /// </summary>
        public static List<Jugador> TotalJugadoresPartido(Partido partido)
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
        public TipoCategoria GetCategoria() => Categoria.AsignarCategoria(this);
        /// <summary>
        /// Define el tipo de ordenamiento que tendrá esta clase.<para/>
        /// Primero se ordena por valor de mercado (descebdebte), en caso de coincidir, alfabeticamente (ascendente).
        /// </summary>
        public int CompareTo([AllowNull] Jugador other)
        {
            int i = other.ValorMercado.CompareTo(this.ValorMercado);
            //Si valorMercado es igual para ambos jugadores, ordeno alfabeticamente.
            if (i == 0) i = this.Nombre.CompareTo(other.Nombre);
            return i;
        }
        /// <summary>
        /// Retorna el listado de partidos en los que participó un jugador determinado.
        /// </summary>
        public static List<Partido> GetPartidos(Jugador jugador)
        {
            List<Partido> partidosJugados = new List<Partido>();
            //Traigo la selección a la que pertenece el jugador.
            Seleccion seleccion = Seleccion.GetSeleccion(jugador);
            //Recorro los partidos y me quedo con los jugados por dicha selección.
            foreach (Partido partido in Administradora.Instance.Partidos)
            {
                if (seleccion.JugadoPorEstaSeleccion(partido)) partidosJugados.Add(partido);
            }
            return partidosJugados;
        }

        //Getters && Setters
        public int Id { get { return this.id; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public Posicion Posicion { get { return this.posicion; } set { this.posicion = value; } }
        public string NumeroCamiseta { get { return this.numeroCamiseta; } set { this.numeroCamiseta = value; } }
        public DateTime FechaNacimiento { get { return this.fechaNacimiento; } set { this.fechaNacimiento = value; } }
        public int AlturaCM { get { return this.alturaCM; } set { this.alturaCM = value; } }
        public Pie PieHabil { get { return this.pieHabil; } set { this.pieHabil = value; } }
        public int ValorMercado { get { return this.valorMercado; } set { this.valorMercado = value; } }
        public Moneda Moneda { get { return this.moneda; } set { this.moneda = value; } }
        public Pais Pais { get { return this.pais; } set { this.pais = value; } }
    }
}

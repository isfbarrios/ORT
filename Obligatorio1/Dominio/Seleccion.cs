using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Seleccion
    {
        //Atributos
        private static int autoIncrementId;
        private int id;
        private Pais pais;
        private List<Jugador> jugadores;

        //Constructores
        public Seleccion()
        {
            this.id = ++autoIncrementId;
        }
        public Seleccion(Pais pais)
        {
            this.id = ++autoIncrementId;
            this.pais = pais;
        }

        /// <summary>
        /// Genera el alta de la Seleccion en el sistema.
        /// </summary>
        public static bool AltaSeleccion(Seleccion seleccion)
        {
            bool retVal = false;
            //Si el pais es valido y tiene al menos once jugadores, lo guardo
            if (seleccion.EsSeleccionValida())
            {
                Administradora.Instance.Selecciones.Add(seleccion);
                retVal = true;
            }
            return retVal;
        }
        /// <summary>
        /// Realiza la precarga de datos de Seleccion en el sistema.
        /// </summary>
        public static void PrecargaSelecciones()
        {
            //Contamos con países y jugadores, la seleccion debe armar para cada pais una seleccion
            foreach (Pais pais in Administradora.Instance.Paises)
            {
                //Se crea una seleccion por cada país en la lista.
                Seleccion nuevaSeleccion = new Seleccion(pais);

                List<Jugador> jugadores = ListarJugadores(pais);

                //Recorro los jugadores de dicha selección
                foreach (Jugador j in jugadores)
                {
                    nuevaSeleccion.Jugadores.Add(j);
                }
                AltaSeleccion(nuevaSeleccion);
            }
        }
        /// <summary>
        /// Retorna TRUE o FALSE si la seleccion es valida o no, respectivamente.
        /// </summary>
        public bool EsSeleccionValida()
        {
            return (!this.Pais.EsPaisVacio() && this.Jugadores.Count > +11);
        }
        /// <summary>
        /// Retorna todos los jugadores de una selección, a partir del país del jugador.
        /// </summary>
        /// <returns>Lista de jugadores del país seleccionado</returns>
        private static List<Jugador> ListarJugadores(Pais pais)
        {
            List<Jugador> selJugadores = new List<Jugador>();

            foreach (Jugador j in Administradora.Instance.Jugadores)
            {
                if (j.Pais.Equals(pais))
                {
                    selJugadores.Add(j);
                }
            }
            return selJugadores;
        }
        /// <summary>
        /// Retorna TRUE si la selección jugó este partido (independientemente si era local o visitante).
        /// </summary>
        public bool JugadoPorEstaSeleccion(Partido partido)
        {
            return (partido.Local.Equals(this) || partido.Visitante.Equals(this));
        }
        /// <summary>
        /// Retorna TRUE si el jugador recibido por parámetro es parte de esta selección.
        /// </summary>
        public bool JugadorDeSeleccion(Jugador jugador)
        {
            return (this.Pais.Equals(jugador.Pais));
        }
        //Getters && Setters
        public int Id
        {
            get { return this.id; }
        }
        public Pais Pais
        {
            get { return this.pais; }
        }
        public List<Jugador> Jugadores
        {
            get { return this.jugadores; }
            set { this.jugadores = value; }
        }
        public bool ValidarSeleccionado()
        {
            return this.jugadores.Count >= 11;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Seleccion
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
        //
        private void PrecargaSelecciones()
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
                    nuevaSeleccion.AgregarJugador(j);
                }
                AltaSeleccion(nuevaSeleccion);
            }
        }

        /// <summary>
        /// Retorna todos los jugadores de una selección, a partir del país del jugador.
        /// </summary>
        /// <param name="p"></param>
        /// <returns>Lista de jugadores del país seleccionado</returns>
        private List<Jugador> ListarJugadores(Pais pais)
        {
            List<Jugador> jugadores = new List<Jugador>();
            foreach (Jugador j in Jugadores)
            {
               /*
                if (j.Pais.Nombre.Equals(p.Nombre))
                {
                    _misJugadores.Add(j);
                }
               */
            }
            return jugadores;
        }

        private bool AgregarJugador(Jugador jugador)
        {
            return true;
        }

        private bool AltaSeleccion(Seleccion seleccion)
        {
            return true;
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Seleccion
    {
        private int id;
        private Pais pais;
        private List<Jugador> jugadores;

        public Seleccion() { }
        public Seleccion(Pais pais)
        {
            this.pais = pais;
        }
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Seleccion
    {
        //Atributos
        private int id;
        private Pais pais;
        private List<Jugador> jugadores;

        //Constructores
        public Seleccion() {}
        public Seleccion(Pais pais, List<Jugador> jugadores)
        {
            this.pais = pais;
            this.jugadores = jugadores;
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

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
        public Seleccion(Pais pais, List<Jugador> jugadores)
        {
            this.id = ++autoIncrementId;
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

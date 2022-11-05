using System;
using System.Collections.Generic;
using System.Text;

namespace consApp
{
    public class Persona
    {
        //Atributos
        private static int autoIncrementId;
        private int id;
        private String nombre;
        private int edad;

        public Persona() { }

        public Persona(String nombre = "S/D", int edad = 1)
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        public int Id
        {
            get { return this.id; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public int Edad
        {
            get { return this.edad; }
            set { this.edad = value; }
        }
    }
}

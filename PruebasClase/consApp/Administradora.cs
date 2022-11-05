using System;
using System.Collections.Generic;
using System.Text;

namespace consApp
{
    class Administradora
    {
        private static Administradora instance;

        private List<Persona> personas = new List<Persona>();

        private Administradora() { }
        public static Administradora Instance
        {
            get
            {
                if (instance == null) instance = new Administradora();
                return instance;
            }
        }
        public List<Persona> Personas
        {
            get { return this.personas; }
        }
    }
}

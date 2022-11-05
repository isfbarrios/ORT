using System;
using System.Collections.Generic;

namespace proyy
{
    public class Sistema
    {
        private static Sistema instance;
        private List<Persona> personas = new List<Persona>();

        private Sistema() { }
        public static Sistema Instance
        {
            get
            {
                if (instance == null) instance = new Sistema();
                return instance;
            }
        }
        public List<Persona> Personas
        {
            get { return this.personas; }
        }

        public static Persona BuscarPersona(int id)
        {
            Persona retVal = null;
            foreach (Persona p in Instance.Personas)
            {
                if (p.Id == id) retVal = p;
            }
            return retVal;
        }
    }
}

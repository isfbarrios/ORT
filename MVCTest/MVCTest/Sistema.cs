using System;

namespace MVCTest
{
    public class Sistema
    {
        private static Sistema instance;

        private List<Persona> personas = new List<Persona>();

        private int minimoParaVIP = 0;

        private Sistema()
        {

        }
        public static Sistema Instance
        {
            get
            {
                if (instance == null) instance = new Sistema();
                return instance;
            }
        }
    }
}

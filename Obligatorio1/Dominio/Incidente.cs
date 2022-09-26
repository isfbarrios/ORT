using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Incidente
    {
        //Atributos
        private static int autoIncrementId;
        private int id;
        private TipoIncidente tipoIncidente;
        private int minuto;
        private Partido partido;

        //Constructores
        public Incidente() 
        {
            this.id = ++autoIncrementId;
        }

        public Incidente(TipoIncidente tipoIncidente, Partido partido, int minuto = -1)
        {
            this.id = ++autoIncrementId;
            this.tipoIncidente = tipoIncidente;
            this.minuto = minuto;
            this.partido = partido;
        }
        
        public static bool AltaIncidente(Incidente incidente)
        {
            bool retVal = false;

            /*
             * Validaciones:
             * 1 - Amonestaciones: no acumular más de dos sobre un mismo jugador.
             * 2 - Expulsiones: no acumular más de una sobre un mismo jugador.
            */


            return retVal;
        }
        


        //Getters && Setters
        public int Id {
            get {return this.id;} 
        }
        public TipoIncidente TipoIncidente
        {
            get { return this.tipoIncidente; }
        }
        public int Minuto
        {
            get { return this.minuto; }
        }
        public Partido Partido
        {
            get { return this.partido; }
        }
    }
}

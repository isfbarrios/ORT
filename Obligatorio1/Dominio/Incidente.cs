using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Incidente
    {
        //Atributos
        private int id;
        private TipoIncidente tipoIncidente;
        private int minuto;
        private Partido partido;

        //Constructores
        public Incidente() {}

        public Incidente(TipoIncidente tipoIncidente, int minuto, Partido partido)
        {
            this.tipoIncidente = tipoIncidente;
            this.minuto = minuto;
            this.partido = partido;
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

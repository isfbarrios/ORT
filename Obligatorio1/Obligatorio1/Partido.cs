using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio1
{
    class Partido
    {
        private int id;
        private Seleccion seleccion;
        private DateTime fecha;
        private bool finalizado;
        private Resultado resultado;
        //Estos puede que no sean para agregar acá
        private Fase fase;
        private Etapa etapa;
        
        public int Id
        {
            get { return this.id; }
        }
        public Seleccion Seleccion
        {
            get { return this.seleccion; }
            set { this.seleccion = value; }
        }
        public DateTime Fecha
        {
            get { return this.fecha; }
        }
        public bool Finalizado
        {
            get { return this.finalizado; }
            set { this.finalizado = value; }
        }
        public Resultado Resultado
        {
            get { return this.resultado; }
            set { this.resultado = value; }
        }
        public Fase Fase
        {
            get { return this.fase; }
        }
        public Etapa Etapa
        {
            get { return this.etapa; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class FaseEliminatoria : Partido
    {
        private Etapa etapa;

        //Constructores
        public FaseEliminatoria() : base() { }

        public FaseEliminatoria(Seleccion local, Seleccion visitante, 
            DateTime fecha, Etapa etapa) : base(local, visitante, fecha) 
        {
            this.etapa = etapa;
        }

        //Funcionalidad
        public static bool AltaPartido(FaseEliminatoria fe)
        {
            bool retVal = false;
            if (fe.Validar())
            {
                Administradora.Instance.Partidos.Add(fe);
                retVal = true;
            }
            return retVal;
        }

        /// <summary>
        /// Retorna el objecto en formato string.
        /// </summary>
        public override string ToString() => ($"Partido Nº {this.Id}. Etapa {this.Etapa}.\n" +
            $"Fecha {this.Fecha}.\n" +
            $"(Local) {this.Local.Pais.Nombre} vs (Visitante) {this.Visitante.Pais.Nombre}.");

        //Getters & Setters
        public Etapa Etapa { get { return this.etapa; } set { this.etapa = value; } }
    }
}

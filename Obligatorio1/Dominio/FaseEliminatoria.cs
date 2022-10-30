using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class FaseEliminatoria : Partido
    {
        private Etapa etapa;
        /// <summary>
        /// Retorna el objecto en formato string.
        /// </summary>
        public override string ToString() => ($"Partido Nº {this.Id}. Etapa {this.Etapa}.\n" +
            $"Fecha {this.Fecha}.\n" +
            $"(Local) {this.Local.Pais.Nombre} vs (Visitante) {this.Visitante.Pais.Nombre}.");

        public Etapa Etapa
        {
            get { return this.etapa; }
            set { this.etapa = value; }
        }
    }
}

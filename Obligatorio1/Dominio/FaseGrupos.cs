using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class FaseGrupos : Partido
    {
        private Grupo grupo;

        /// <summary>
        /// Retorna el objecto en formato string.
        /// </summary>
        public override string ToString() => ($"Partido Nº {this.Id}. Grupo {this.Grupo}.\n" +
            $"Fecha {this.Fecha}.\n" +
            $"(Local) {this.Local.Pais.Nombre} vs (Visitante) {this.Visitante.Pais.Nombre}.");

        public Grupo Grupo
        {
            get { return this.grupo; }
            set { this.grupo = value; }
        }
    }
}

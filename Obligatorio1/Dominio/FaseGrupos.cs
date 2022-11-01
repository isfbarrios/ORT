using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class FaseGrupos : Partido
    {
        private Grupo grupo;

        //Constructores
        public FaseGrupos() : base() { }

        public FaseGrupos(Seleccion local, Seleccion visitante, DateTime fecha, Grupo grupo) : base(local, visitante, fecha)
        {
            this.grupo = grupo;
        }
        
        //Funcionalidad

        /// <summary>
        /// Retorna el objecto en formato string.
        /// </summary>
        public override string ToString() => ($"Partido Nº {this.Id}. Grupo {this.Grupo}.\n" +
            $"Fecha {this.Fecha}.\n" +
            $"(Local) {this.Local.Pais.Nombre} vs (Visitante) {this.Visitante.Pais.Nombre}.");

        public static bool AltaPartido(FaseGrupos partido)
        {
            bool retVal = false;
            if (Partido.EsPartidoValido(partido))
            {
                Administradora.Instance.Partidos.Add(partido);
                retVal = true;
            }
            return retVal;
        }

        public Grupo Grupo
        {
            get { return this.grupo; }
            set { this.grupo = value; }
        }
    }
}

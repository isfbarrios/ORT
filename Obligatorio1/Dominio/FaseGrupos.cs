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

        public FaseGrupos(Seleccion local, Seleccion visitante, 
            DateTime fecha, Grupo grupo) : base(local, visitante, fecha)
        {
            this.grupo = grupo;
        }

        //Funcionalidad

        public override string ToString() => ($"Partido Nº {this.Id}. Grupo {this.Grupo}.\n" +
            $"Fecha {this.Fecha}.\n" +
            $"(Local) {this.Local.Pais.Nombre} vs (Visitante) {this.Visitante.Pais.Nombre}.");

        public override bool FinalizarPartido() 
        {
            bool retVal = false;
            //Ejecuto las acciones únicamente si está sin finalizar.
            if (!this.Finalizado)
            {
                retVal = true;
                //Lo paso a finalizado
                this.Finalizado = true;
                int resultado = this.CalcularResultado();

                if (resultado == 0) this.Resultado = Resultado.EMPATE;
                else if (resultado == -1) this.Resultado = Resultado.LOCAL;
                else if (resultado == 1) this.Resultado = Resultado.VISITANTE;
            }
            return retVal;
        }
        /// <summary>
        /// Recorre las incidencias de Gol de un partido.
        /// Retorna un valor númerico dependiendo si el ganador fue el equipo local (-1), empate (0) o si el ganador fue el equipo visitante (1).
        /// </summary>
        public override int CalcularResultado()
        {
            int local = 0, visitante = 0;
            //Consulto que selección realizo más goles en ese partido
            foreach (Incidente i in this.GetIncidentesDeGol())
            {
                if (i.Jugador.Pais.Equals(this.Local.Pais)) local++;
                else visitante++;
            }
            return (local > visitante ? -1 : (local == visitante ? 0 : 1));
        }

        public override string ExpresarResultado()
        {
            string retVal = this.Resultado == Resultado.EMPATE ? "Empate" : "Ganador: ";
            if (retVal == "Ganador") retVal += this.Resultado == Resultado.LOCAL ? this.Local.ToString() : this.Visitante.ToString();
           
            return retVal;
        }
        public static bool AltaPartido(FaseGrupos fg)
        {
            bool retVal = false;
            if (fg.Validar())
            {
                Administradora.Instance.Partidos.Add(fg);
                retVal = true;
            }
            return retVal;
        }
        public override string GetPartidoType() => "Grupos";

        public override string GetFase() => this.Grupo.ToString();

        //Getters & Setters
        public Grupo Grupo { get { return this.grupo; } set { this.grupo = value; } }
    }
}

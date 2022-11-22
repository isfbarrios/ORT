using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class FaseEliminatoria : Partido
    {
        private Etapa etapa;
        private bool penales;

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
        /// Dispara el evento de finalizaci'on de un partido. Retorna True si la acción resulta exitosa.
        /// </summary>
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

                if (resultado == -1) this.Resultado = Resultado.LOCAL;
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
                //Si se encuentra que algún incidente se dio en tanda de penales, significa que la definición del partido fue por esta vía.
                if (!this.Penales && i.Minuto == -1) this.Penales = true;

                if (i.Jugador.Pais.Equals(this.Local.Pais)) local++;
                else visitante++;
            }
            return (local > visitante ? -1 : (local == visitante ? 0 : 1));
        }
        /// <summary>
        /// Retorna el resultado del partido.
        /// </summary>
        public override string ExpresarResultado()
        {
            string retVal = this.Penales ? "Empate en tiempo de juego. Ganador " : "Ganador: ";
            retVal += this.Resultado == Resultado.LOCAL ? this.Local.ToString() : this.Visitante.ToString();
            retVal += this.Penales ? " en tanda de penales." : ".";
            
            return retVal;
        }

        public override string ToString() => ($"Partido Nº {this.Id}. Etapa {this.Etapa}.\n" +
            $"Fecha {this.Fecha}.\n" +
            $"(Local) {this.Local.Pais.Nombre} vs (Visitante) {this.Visitante.Pais.Nombre}.");

        public override string GetPartidoType() => "Eliminatoria";

        public override string GetFase() => this.Etapa.ToString();

        //Getters & Setters
        public Etapa Etapa { get { return this.etapa; } set { this.etapa = value; } }
        public bool Penales { get { return this.penales; } set { this.penales = value; } }
    }
}

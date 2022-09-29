using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Partido
    {
        //Atributos
        private static int autoIncrementId;
        private int id;
        private Seleccion local;
        private Seleccion visitante;
        private DateTime fecha;
        private bool finalizado;
        private Resultado resultado;
        private List<Incidente> incidentes;
        //Estos puede que no sean para agregar acá
        private Fase fase;
        private Etapa etapa;

        //Constructores
        public Partido() 
        {
            this.id = ++autoIncrementId;
        }

        public Partido(Seleccion local, Seleccion visitante, DateTime fecha, List<Incidente> incidentes, Fase fase, Etapa etapa)
        {
            this.id = ++autoIncrementId;
            this.local = local;
            this.visitante = visitante;
            this.fecha = fecha;
            this.finalizado = false; //Por defecto, no finalizado
            this.incidentes = incidentes;
            this.resultado = Resultado.PENDIENTE;
            this.fase = fase;
            this.etapa = etapa;
        }

        //Funcionalidades
        public static bool AltaPartido(Partido partido)
        {
            bool retVal = false;
            if (Partido.EsPartidoValido(partido))
            {
                Administradora.Instance.Partidos.Add(partido);
                retVal = true;
            }
            return retVal;
        }
        /// <summary>
        /// Retorna TRUE si el partido cumple con la condicion de tener Selecciones validas para Local y Visitante.
        /// </summary>
        public static bool EsPartidoValido(Partido partido)
        {
            return (partido.Local.EsSeleccionValida() && partido.Visitante.EsSeleccionValida());
        }
        private bool ValidarFechaDePartido()
        {
            bool retVal = false;
            DateTime dateFrom = Convert.ToDateTime("20/11/2022");
            DateTime dateTo = Convert.ToDateTime("18/12/2022");

            if (this.Fecha >= dateFrom && this.Fecha <= dateTo)
            {
                retVal = true;
            }
            return retVal;
        }

        //Getters & Setters
        public int Id
        {
            get { return this.id; }
        }
        public Seleccion Local
        {
            get { return this.local; }
            set { this.local = value; }
        }
        public Seleccion Visitante
        {
            get { return this.visitante; }
            set { this.visitante = value; }
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
        public List<Incidente> Incidentes
        {
            get { return this.incidentes; }
        }
        public Etapa Etapa
        {
            get { return this.etapa; }
        }
    }
}

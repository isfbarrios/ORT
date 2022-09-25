using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Resena
    {
        //Atributos
        private static int autoIncrementId;
        private int id;
        private Periodista periodista;
        private Partido partido;
        private DateTime fecha;
        private String titulo;
        private String contenido;

        //Constructores
        public Resena() 
        {
            this.id = ++autoIncrementId;
        }

        public Resena(Periodista periodista, String titulo, String contenido)
        {
            this.id = ++autoIncrementId;
            this.periodista = periodista;
            this.fecha = new DateTime(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            this.titulo = titulo;
            this.contenido = contenido;
        }
        /// <summary>
        /// Genera el alta del Periodista en el sistema.
        /// </summary>
        public static bool AltaResena(Resena resena)
        {
            bool retVal = false;
            if (resena.Id != 0)
            {
                Administradora.Instance.Resenas.Add(resena);
                retVal = true;
            }
            return retVal;
        }

        //Getters & Setters
        public int Id
        {
            get { return this.id; }
        }
        public Periodista Periodista
        {
            get { return this.periodista; }
        }
        public Partido Partido
        {
            get { return this.partido; }
        }
        public DateTime Fecha
        {
            get { return this.fecha; }
        }
        public String Titulo
        {
            get { return this.titulo; }
        }
        public String Contenido
        {
            get { return this.contenido; }
        }
    }
}

﻿using System;
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
        private string titulo;
        private string contenido;

        //Constructores
        public Resena() 
        {
            this.id = ++autoIncrementId;
        }

        public Resena(Periodista periodista, Partido partido, string titulo, string contenido)
        {
            this.id = ++autoIncrementId;
            this.periodista = periodista;
            this.fecha = DateTime.Now;
            this.partido = partido;
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
        public string Titulo
        {
            get { return this.titulo; }
        }
        public string Contenido
        {
            get { return this.contenido; }
        }
    }
}

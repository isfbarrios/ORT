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
        private String titulo;
        private String contenido;

        //Constructores
        public Resena() 
        {
            this.id = ++autoIncrementId;
        }

        public Resena(Periodista periodista, DateTime fecha, String titulo, String contenido)
        {
            this.id = ++autoIncrementId;
            this.periodista = periodista;
            this.fecha = fecha;
            this.titulo = titulo;
            this.contenido = contenido;
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

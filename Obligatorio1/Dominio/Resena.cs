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
        
        //Funcionalidades

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
        public static List<Resena> GetResenas(Periodista periodista)
        {
            List<Resena> retVal = new List<Resena>();
            foreach (Resena r in Administradora.Instance.Resenas)
            {
                if (r.Periodista.Equals(periodista)) retVal.Add(r);
            }
            return retVal;
        }
        public static Resena GetResena(int id)
        {
            Resena retVal = null;
            foreach (Resena r in Administradora.Instance.Resenas)
            {
                if (r.Id == id) retVal = r;
            }
            return retVal;
        }
        public override string ToString() => ($"Nombre {this.Periodista.Nombre} {this.Titulo} - Mail {this.Contenido}");
        
        //Getters & Setters
        
        public int Id { get { return this.id; } }
        public Periodista Periodista { get { return this.periodista; } set { this.periodista = value; } }
        public Partido Partido { get { return this.partido; } set { this.partido = value; } }
        public DateTime Fecha { get { return this.fecha; } set { this.fecha = value; } }
        public string Titulo { get { return this.titulo; } set { this.titulo = value; } }
        public string Contenido { get { return this.contenido; } set { this.contenido = value; } }
    }
}

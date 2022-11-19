using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Resena : IValidar
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

        public static bool CrearResena(Periodista periodista, string titulo, string contenido, Partido partido)
        {
            bool retVal = false;
            Resena resena = new Resena(periodista, partido, titulo, contenido);

            if (resena.Validar())
            {
                retVal = true;
                periodista.ListaResenas.Add(resena);
                Administradora.Instance.Resenas.Add(resena);
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

        public bool Validar() => partido != null && partido.Finalizado && titulo.Length > 0 && contenido.Length > 0;

        //Getters & Setters

        public int Id { get { return this.id; } }
        public Periodista Periodista { get { return this.periodista; } set { this.periodista = value; } }
        public Partido Partido { get { return this.partido; } set { this.partido = value; } }
        public DateTime Fecha { get { return this.fecha; } set { this.fecha = value; } }
        public string Titulo { get { return this.titulo; } set { this.titulo = value; } }
        public string Contenido { get { return this.contenido; } set { this.contenido = value; } }
    }
}

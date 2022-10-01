﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Periodista
    {
        //Atributos
        private static int autoIncrementId;
        private int id;
        private string nombre;
        private string apellido;
        private string mail;
        private string password;
        private List<Resena> listaResenas;

        //Constructores
        public Periodista() 
        {
            this.id = ++autoIncrementId;
        }

        public Periodista(string nombre, string apellido, string mail, string password)
        {
            this.id = ++autoIncrementId;
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.password = password;
            this.listaResenas = new List<Resena>();
        }

        /// <summary>
        /// Genera el alta del Periodista en el sistema.
        /// </summary>
        public static bool AltaPeriodista(Periodista periodista)
        {
            bool retVal = false;
            if (periodista.ValidarNombre() && periodista.ValidarMail() && periodista.ValidarPassword())
            {
                Administradora.Instance.Periodistas.Add(periodista);
                retVal = true;
            }
            return retVal;
        }

        /// <summary>
        /// Genera un nuevo objeto Resena en el sistema.
        /// </summary>
        public bool crearResena(string titulo, string contenido)
        {
            bool retVal = false;
            DateTime fecha = DateTime.Now;
            if (titulo.Length > 0 && contenido.Length > 0)
            {
                Resena resena = new Resena(this, new Partido(), titulo, contenido);
                listaResenas.Add(resena);
                Administradora.Instance.Resenas.Add(resena);
            }
            return retVal;
        }
        /// <summary>
        /// Valida que el password cumpla con el largo requerido.
        /// </summary>
        public bool ValidarPassword() => Utils.ValidLength(this.Password, 8);
        /// <summary>
        /// Valida que el mail contenga un @, pero no se encuentre en la primer o última posición.
        /// </summary>
        public bool ValidarMail() => (this.Mail.Length > 0 && this.Mail.IndexOf("@") > 0 && !this.Mail.StartsWith("@") && !this.Mail.EndsWith("@") && !ValidarMailRepetido(this.Mail));
        private bool ValidarMailRepetido(String mail)
        {
            bool retVal = false;
            foreach (Periodista periodista in Administradora.Instance.Periodistas) 
            {
                if (mail.Equals(periodista.Mail))
                {
                    retVal = true;
                    break;
                }
            }
            return retVal;
        }
        /// <summary>
        /// Valida que el nombre completo del periodista sea valido.
        /// </summary>
        public bool ValidarNombre() => (this.Nombre.Length > 0 && this.Apellido.Length > 0);
        /// <summary>
        /// Retorna el objecto en formato string.
        /// </summary>
        public override string ToString() => ($"Nombre {this.Nombre} {this.Apellido} - Mail {this.Mail}");
        //Getters & Setters
        public int Id
        {
            get { return this.id; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }
        public string Mail
        {
            get { return this.mail; }
            set { this.mail = value; }
        }
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        public List<Resena> ListaResenas
        {
            get { return this.listaResenas; }
        }
        public static void PrecargaPeriodistas()
        {
            Periodista.AltaPeriodista(new Periodista("Fabricio", "Barrios", "fabribarriosesi@gmail.com", "nosoyreal1234"));
        }
    }
}

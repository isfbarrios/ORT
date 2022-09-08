using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Periodista
    {
        private int id;
        private String nombre;
        private String apellido;
        private String mail;
        private String password;
        private List<Resena> resenas;

        public Periodista() { }

        public Periodista(String nombre, String apellido, String mail, String password)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.password = password;
        }

        public bool crearResena(String titulo, String contenido)
        {
            bool retVal = false;
            DateTime fecha = DateTime.Now;
            if (titulo.Length > 0 && contenido.Length > 0)
            {
                Resena resena = new Resena(this, fecha, titulo, contenido);
                resenas.Add(resena);

                Administradora.Instance.Resenas.Add(resena);
            }

            return retVal;
        }

        /// <summary>
        /// Valida que el password cumpla con el largo requerido.
        /// </summary>
        public static bool ValidPassword(String pass)
        {
            return Utils.ValidLength(pass, 8);
        }
        /// <summary>
        /// Valida que el mail contenga un @, pero no se encuentre en la primer o última posición.
        /// </summary>
        public static bool ValidMail(String mail)
        {
            if (mail.Length > 0 && mail.IndexOf("@") > 0)
            {
                if (!mail.StartsWith("@") && !mail.EndsWith("@"))
                {
                    return true;
                }
            }
            return false;
        }

        //Getters & Setters
        public int Id
        {
            get { return this.id; }
        }
        public String Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public String Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }
        public String Mail
        {
            get { return this.mail; }
            set { this.mail = value; }
        }
        public String Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        public List<Resena> Resenas
        {
            get { return this.resenas; }
        }
    }
}

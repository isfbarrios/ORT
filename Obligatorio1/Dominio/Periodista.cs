using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Periodista
    {
        //Atributos
        private static int autoIncrementId;
        private int id;
        private String nombre;
        private String apellido;
        private String mail;
        private String password;
        private List<Resena> listaResenas;

        //Constructores
        public Periodista() 
        {
            this.id = ++autoIncrementId;
        }

        public Periodista(String nombre, String apellido, String mail, String password)
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
        public bool crearResena(String titulo, String contenido)
        {
            bool retVal = false;
            DateTime fecha = DateTime.Now;
            if (titulo.Length > 0 && contenido.Length > 0)
            {
                Resena resena = new Resena(this, fecha, titulo, contenido);
                listaResenas.Add(resena);
                Administradora.Instance.Resenas.Add(resena);
            }
            return retVal;
        }

        /// <summary>
        /// Valida que el password cumpla con el largo requerido.
        /// </summary>
        public bool ValidarPassword()
        {
            return Utils.ValidLength(this.Password, 8);
        }
        /// <summary>
        /// Valida que el mail contenga un @, pero no se encuentre en la primer o última posición.
        /// </summary>
        public bool ValidarMail()
        {
            if (this.Mail.Length > 0 && this.Mail.IndexOf("@") > 0)
            {
                if (!this.Mail.StartsWith("@") && !this.Mail.EndsWith("@")) return true;
            }
            return false;
        }
        /// <summary>
        /// Valida que el nombre completo del periodista sea valido.
        /// </summary>
        public bool ValidarNombre()
        {
            if (this.Nombre.Length > 0 && this.Apellido.Length > 0) return true;
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
        public List<Resena> ListaResenas
        {
            get { return this.listaResenas; }
        }
    }
}

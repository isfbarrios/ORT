using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dominio;

namespace Dominio
{
    public abstract class Usuario : IComparable<Usuario>, IValidar
    {
        //Atributos
        private static int autoIncrementId;
        private int id;
        private string nombre;
        private string apellido;
        private string mail;
        private string password;

        //Constructores
        public Usuario()
        {
            this.id = ++autoIncrementId;
        }
        public Usuario(string nombre, string apellido, string mail, string password)
        {
            this.id = ++autoIncrementId;
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.password = password;
        }
        public bool Validar() => (Administradora.ValidLength(this.Password, 8)
            && Administradora.ValidMail(this.Mail) && !ValidarMailUsuario(this.Mail)
            && this.Nombre.Length > 0 && this.Nombre.IndexOf(" ") == -1);

        private bool ValidarNombreCompleto() => this.Nombre.Length > 0
            && this.Nombre.IndexOf(" ") == -1 && this.Apellido.Length > 0 && this.Apellido.IndexOf(" ") == -1;

        public abstract override string ToString();

        public abstract string GetUserType();

        public static Usuario GetUserById(int id)
        {
            Usuario retVal = new Operador();

            foreach (Usuario u in Administradora.Instance.Usuarios)
            {
                if (u.Id == id) retVal = u;
            }
            return retVal;
        }

        public bool ValidarMailUsuario(String mail)
        {
            bool retVal = false;
            foreach (Periodista periodista in Administradora.Instance.Usuarios)
            {
                if (mail.Equals(periodista.Mail))
                {
                    retVal = true;
                    break;
                }
            }
            return retVal;
        }
        public int CompareTo([AllowNull] Usuario other)
        {
            return this.Id.CompareTo(other.Id);
        }

        //Getters & Setters
        public int Id { get { return this.id; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Apellido { get { return this.apellido; } set { this.apellido = value; } }
        public string Mail { get { return this.mail; } set { this.mail = value; } }
        public string Password { get { return this.password; } set { this.password = value; } }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Periodista:IComparable<Periodista>, IValidar
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
            if (periodista.Validar())
            {
                Administradora.Instance.Periodistas.Add(periodista);
                retVal = true;
            }
            return retVal;
        }
        /// <summary>
        /// Genera un nuevo objeto Resena en el sistema.
        /// </summary>
        /*public bool CrearResena(string titulo, string contenido)
        {
            bool retVal = false;
            DateTime fecha = DateTime.Now;
            if (titulo.Length > 0 && contenido.Length > 0)
            {
                FaseEliminatoria fe = new FaseEliminatoria
                Resena resena = new Resena(this, new Partido(), titulo, contenido);
                listaResenas.Add(resena);
                Administradora.Instance.Resenas.Add(resena);
            }
            return retVal;
        }*/
        public bool Validar() => (Administradora.ValidLength(this.Password, 8) && Administradora.ValidMail(this.Mail) && !ValidarMailPeriodista(this.Mail)
            && this.Nombre.Length > 0 && this.Nombre.IndexOf(" ") == -1);
        private bool ValidarNombreCompleto() => this.Nombre.Length > 0 
            && this.Nombre.IndexOf(" ") == -1 && this.Apellido.Length > 0 && this.Apellido.IndexOf(" ") == -1;
        /// <summary>
        /// Valida únicamente que el mail no este repetido entre los usados por aquellos Periodistas ya registrados.
        /// </summary>
        private bool ValidarMailPeriodista(String mail)
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
        /// Retorna el Periodista según el nombre. Si no existe, retorna Null.
        /// </summary>
        public static Periodista GetPeriodista(String nombre)
        {
            Periodista retVal = null;
            foreach (Periodista p in Administradora.Instance.Periodistas)
            {
                if (p.Nombre == nombre) retVal = p;
            }
            return retVal;
        }
        /// <summary>
        /// Retorna el objecto en formato string.
        /// </summary>
        public override string ToString() => ($"Nombre {this.Nombre} {this.Apellido} - Mail {this.Mail}");
        /// <summary>
        /// Define el tipo de ordenamiento que tendrá esta clase. Se ordena por Id.
        /// </summary>
        public int CompareTo([AllowNull] Periodista other)
        {
            return this.Id.CompareTo(other.Id);
        }

        //Getters & Setters
        public int Id { get { return this.id; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Apellido { get { return this.apellido; } set { this.apellido = value; } }
        public string Mail { get { return this.mail; } set { this.mail = value; } }
        public string Password { get { return this.password; } set { this.password = value; } }
        public List<Resena> ListaResenas { get { return this.listaResenas; } }
    }
}

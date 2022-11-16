using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Operador
    {
        //nombre, apellido, email, contraseña y fecha en que comenzó a trabajar
        private static int autoIncrementId;
        private int id;
        private string nombre;
        private string apellido;
        private string mail;
        private string password;
        private DateTime fechaIngreso;

        //Constructores
        public Operador()
        {
            this.id = ++autoIncrementId;
        }
        public Operador(string nombre, string apellido, string mail, string password, DateTime fechaIngreso)
        {
            this.id = ++autoIncrementId;
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.password = password;
            this.fechaIngreso = fechaIngreso;
        }
        //Funcionalidades

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
        //Getters & Setters
        public int Id { get { return this.id; } }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Apellido { get { return this.apellido; } set { this.apellido = value; } }
        public string Mail { get { return this.mail; } set { this.mail = value; } }
        public string Password { get { return this.password; } set { this.password = value; } }
        public DateTime FechaIngreso { get { return this.fechaIngreso; } set { this.fechaIngreso = value; } }
    }
}

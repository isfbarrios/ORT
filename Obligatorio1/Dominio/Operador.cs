using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Operador : Usuario
    {
        //Atributos
        private DateTime fechaIngreso;

        //Constructores
        public Operador() : base() { }

        public Operador(string nombre, string apellido, string mail, 
            string password, DateTime fechaIngreso) : base(nombre, apellido, mail, password)
        {
            this.fechaIngreso = fechaIngreso;
        }
        //Funcionalidades
        public static Periodista GetPeriodista(String nombre)
        {
            Periodista retVal = null;
            foreach (Periodista p in Administradora.Instance.Usuarios)
            {
                if (p.Nombre == nombre) retVal = p;
            }
            return retVal;
        }

        public static Usuario GetOperador(string nombre)
        {
            Operador retVal = null;
            foreach (Operador p in Administradora.Instance.Usuarios)
            {
                if (p.Nombre == nombre) retVal = p;
            }
            return retVal;
        }

        public override string GetUserType() => "Operador";

        public override string ToString() => ($"Nombre {this.Nombre} {this.Apellido} - Mail {this.Mail}");

        //Getters & Setters
        public DateTime FechaIngreso { get { return this.fechaIngreso; } set { this.fechaIngreso = value; } }
    }
}

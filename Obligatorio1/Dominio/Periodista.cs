using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Periodista : Usuario
    {
        //Atributos
        private List<Resena> listaResenas;

        //Constructores
        public Periodista() : base() { }
        public Periodista(string nombre, string apellido, 
            string mail, string password) : base(nombre, apellido, mail, password)
        {
            this.listaResenas = new List<Resena>();
        }

        public static bool AltaPeriodista(Usuario periodista)
        {
            bool retVal = false;
            if (periodista.Validar())
            {
                Administradora.Instance.Usuarios.Add(periodista);
                retVal = true;
            }
            return retVal;
        }
        public override string GetUserType() => "Periodista";

        public override string ToString() => ($"Nombre {this.Nombre} {this.Apellido} - Mail {this.Mail}");

        //Getters & Setters
        public List<Resena> ListaResenas { get { return this.listaResenas; } }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Dominio
{
    public class Periodista : Usuario, IComparable<Periodista>
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
        
        public static List<Partido> GetPartidosResenados(Periodista p)
        {
            List<Partido> retVal = new List<Partido>();

            if (p.ListaResenas.Count > 0)
            {
                foreach (Resena r in p.ListaResenas)
                {
                    foreach (Incidente i in r.Partido.Incidentes)
                    {
                        if (!retVal.Contains(i.Partido)) retVal.Add(i.Partido);
                    }
                }
            }
            return retVal;
        }

        public override string GetUserType() => "Periodista";

        public override string ToString() => ($"Nombre {this.Nombre} {this.Apellido} - Mail {this.Mail}");

        public int CompareTo([AllowNull] Periodista other)
        {
            int retVal = this.Apellido.CompareTo(other.Apellido);

            if (retVal == 0) retVal = this.Nombre.CompareTo(other.Nombre);

            return retVal;
        }

        //Getters & Setters
        public List<Resena> ListaResenas { get { return this.listaResenas; } }
    }
}

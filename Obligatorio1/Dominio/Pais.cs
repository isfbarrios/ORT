using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Pais : IValidar
    {
        //Atributos
        private static int autoIncrementId;
        private int id;
        private string nombre;
        private string codigo;
        
        //Constructores
        public Pais() 
        {
            this.id = ++autoIncrementId;
        }
        public Pais(string nombre, string codigo)
        {
            this.id = ++autoIncrementId;
            this.nombre = nombre;
            this.codigo = codigo;
        }
        //Funcionalidades
        public static void AltaPais(Pais pais)
        {
            //Si código tiene tres caracteres y al menos uno, lo guardo.
            if (pais.Validar()) Administradora.Instance.Paises.Add(pais);
        }

        public static Pais GetPais(string nombre)
        {
            foreach (Pais pais in Administradora.Instance.Paises)
            {
                if (pais.Nombre.Equals(nombre)) return pais;
            }
            return null;
        }

        public override string ToString() => ($"País {this.Nombre} [{this.Codigo}");

        public bool Validar() => (this.Nombre.Length > 0 && this.Codigo.Length == 3);

        //Getters y Setters
        public int Id { get; }
        public string Nombre { get { return this.nombre; } set { this.nombre = value; } }
        public string Codigo { get { return this.codigo; } set { this.codigo = value; } }
    }
}

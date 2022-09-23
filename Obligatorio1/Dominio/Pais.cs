using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Pais
    {
        //Atributos
        private static int autoIncrementId;
        private int id;
        private String nombre;
        private String codigo;
        
        //Constructores
        public Pais() 
        {
            this.id = ++autoIncrementId;
        }
        public Pais(String nombre, String codigo)
        {
            this.id = ++autoIncrementId;
            this.nombre = nombre;
            this.codigo = codigo;
        }

        //Funcionalidades

        /// <summary>
        /// Genera el alta del Pais en el sistema.
        /// </summary>
        public static void AltaPais(Pais pais)
        {
            //Si código tiene tres caracteres y al menos uno, lo guardo
            if (!pais.EsPaisVacio())
            {
                Administradora.Instance.Paises.Add(pais);
            }
        }

        /// <summary>
        /// Valida que el objeto sea valido.
        /// </summary>
        public bool EsPaisVacio()
        {
            return (this.Nombre.Length == 0 && !(this.Codigo.Length == 3));
        }

        /// <summary>
        /// Retorna el Pais correspondiente mediante su nombre.
        /// </summary>
        public static Pais GetPais(String nombre)
        {
            foreach (Pais pais in Administradora.Instance.Paises)
            {
                if (pais.Nombre.Equals(nombre)) return pais;
            }
            return null;
        }

        //Getters y Setters
        public int Id
        {
            get { return this.id; }
        }
        public String Nombre
        {
            get { return this.nombre; }
        }
        public String Codigo
        {
            get { return this.codigo; }
        }
    }
}

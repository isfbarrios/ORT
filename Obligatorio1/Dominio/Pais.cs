using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Pais
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
        public static Pais GetPais(string nombre)
        {
            foreach (Pais pais in Administradora.Instance.Paises)
            {
                if (pais.Nombre.Equals(nombre)) return pais;
            }
            return null;
        }
        /// <summary>
        /// Retorna el objecto en formato string.
        /// </summary>
        public override string ToString() => ($"País {this.Nombre} [{this.Codigo}.");
        //Getters y Setters
        public int Id
        {
            get { return this.id; }
        }
        public string Nombre
        {
            get { return this.nombre; }
        }
        public string Codigo
        {
            get { return this.codigo; }
        }

        public static void PreLoadPaises()
        {
            AltaPais(new Pais("Catar", "QAT"));
            AltaPais(new Pais("Alemania", "DEU"));
            AltaPais(new Pais("Dinamarca", "DNK"));
            AltaPais(new Pais("Brasil", "BRA"));
            AltaPais(new Pais("Francia", "FRA"));
            AltaPais(new Pais("Bélgica", "BEL"));
            AltaPais(new Pais("Croacia", "HRV"));
            AltaPais(new Pais("España", "ESP"));
            AltaPais(new Pais("Serbia", "SRB"));
            AltaPais(new Pais("Inglaterra", "GBR"));
            AltaPais(new Pais("Suiza", "CHE"));
            AltaPais(new Pais("Países Bajos", "NLD"));
            AltaPais(new Pais("Argentina", "ARG"));
            AltaPais(new Pais("Irán", "IRN"));
            AltaPais(new Pais("Corea del Sur", "KOR"));
            AltaPais(new Pais("Japón", "JPN"));
            AltaPais(new Pais("Arabia Saudita", "SAU"));
            AltaPais(new Pais("Ecuador", "ECU"));
            AltaPais(new Pais("Uruguay", "URY"));
            AltaPais(new Pais("Canadá", "CAN"));
            AltaPais(new Pais("Ghana", "GHA"));
            AltaPais(new Pais("Senegal", "SEN"));
            AltaPais(new Pais("Marruecos", "MAR"));
            AltaPais(new Pais("Túnez", "TUN"));
            AltaPais(new Pais("Portugal", "PRT"));
            AltaPais(new Pais("Polonia", "POL"));
            AltaPais(new Pais("Camerún", "CMR"));
            AltaPais(new Pais("México", "MEX"));
            AltaPais(new Pais("Estados Unidos", "USA"));
            AltaPais(new Pais("Gales", "WLS"));
            AltaPais(new Pais("Australia", "AUS"));
            AltaPais(new Pais("Costa Rica", "CRI"));
        }
    }
}

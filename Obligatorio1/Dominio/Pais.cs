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
            Pais.AltaPais(new Pais("Catar", "QAT"));
            Pais.AltaPais(new Pais("Alemania", "DEU"));
            Pais.AltaPais(new Pais("Dinamarca", "DNK"));
            Pais.AltaPais(new Pais("Brasil", "BRA"));
            Pais.AltaPais(new Pais("Francia", "FRA"));
            Pais.AltaPais(new Pais("Bélgica", "BEL"));
            Pais.AltaPais(new Pais("Croacia", "HRV"));
            Pais.AltaPais(new Pais("España", "ESP"));
            Pais.AltaPais(new Pais("Serbia", "SRB"));
            Pais.AltaPais(new Pais("Inglaterra", "GBR"));
            Pais.AltaPais(new Pais("Suiza", "CHE"));
            Pais.AltaPais(new Pais("Países Bajos", "NLD"));
            Pais.AltaPais(new Pais("Argentina", "ARG"));
            Pais.AltaPais(new Pais("Irán", "IRN"));
            Pais.AltaPais(new Pais("Corea del Sur", "KOR"));
            Pais.AltaPais(new Pais("Japón", "JPN"));
            Pais.AltaPais(new Pais("Arabia Saudita", "SAU"));
            Pais.AltaPais(new Pais("Ecuador", "ECU"));
            Pais.AltaPais(new Pais("Uruguay", "URY"));
            Pais.AltaPais(new Pais("Canadá", "CAN"));
            Pais.AltaPais(new Pais("Ghana", "GHA"));
            Pais.AltaPais(new Pais("Senegal", "SEN"));
            Pais.AltaPais(new Pais("Marruecos", "MAR"));
            Pais.AltaPais(new Pais("Túnez", "TUN"));
            Pais.AltaPais(new Pais("Portugal", "PRT"));
            Pais.AltaPais(new Pais("Polonia", "POL"));
            Pais.AltaPais(new Pais("Camerún", "CMR"));
            Pais.AltaPais(new Pais("México", "MEX"));
            Pais.AltaPais(new Pais("Estados Unidos", "USA"));
            Pais.AltaPais(new Pais("Gales", "WLS"));
            Pais.AltaPais(new Pais("Australia", "AUS"));
            Pais.AltaPais(new Pais("Costa Rica", "CRI"));
        }
    }
}

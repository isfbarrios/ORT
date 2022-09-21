﻿using System;
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
        public static void AltaPais(Pais pais)
        {
            Administradora.Instance.Paises.Add(pais);
        }
        public static bool ValidarNombre(String nombre)
        {
            return Utils.ValidLength(nombre, 1);
        }
        public static bool ValidarCodigo(String codigo)
        {
            return (codigo.Length == 3);
        }
        public bool EsPaisVacio()
        {
            return (this.nombre.Length == 0 && this.codigo.Length == 0);
        }

        public static Pais GetPais(String nombre)
        {
            foreach (Pais pais in Administradora.Instance.Paises)
            {
                if (pais.Nombre == nombre) return pais;
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

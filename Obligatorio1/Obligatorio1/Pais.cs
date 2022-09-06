﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio1
{
    class Pais
    {
        private int id;
        private String nombre;
        private String codigo;

        public Pais() {}
        public Pais(String nombre, String codigo)
        {
            this.nombre = nombre;
            this.codigo = codigo;
        }
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
    }
}

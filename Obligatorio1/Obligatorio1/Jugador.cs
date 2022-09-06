using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio1
{
    class Jugador
    {
        private int id;
        private String nombre;
        private int numeroCamiseta;
        private DateTime fechaNacimiento;
        private int alturaCM;
        private Pie pieHabil;
        private float valorMercado;
        private Moneda moneda;
        private Pais nacionalidad;
        private Categoria categoria;

        public int Id
        {
            get { return this.id; }
        }
        public String Nombre
        {
            get { return this.nombre; }
        }
        public int NumeroCamiseta
        {
            get { return this.numeroCamiseta; }
        }
        public DateTime FechaNacimiento
        {
            get { return this.fechaNacimiento; }
        }
        public int AlturaCM
        {
            get { return this.alturaCM; }
        }
        public Pie PieHabil
        {
            get { return this.pieHabil; }
        }
        public float ValorMercado
        {
            get { return this.valorMercado; }
        }
        public Moneda Moneda
        {
            get { return this.moneda; }
        }
        public Pais Nacionalidad
        {
            get { return this.nacionalidad; }
        }
        public Categoria Categoria
        {
            get { return this.categoria; }
        }
        public static bool ValidarNombre(String nombre)
        {
            return (Utils.ValidLength(nombre, 0));
        }
        public static bool ValidarNumeroCamiseta(int numeroCamiseta)
        {
            return (numeroCamiseta > 0);
        }
        public static bool ValidarFechaNacimiento(DateTime fechaNacimiento)
        {
            //Date example
            //DateTime thisDate1 = new DateTime(2011, 6, 10); thisDate1.ToString("MMMM dd, yyyy")
            return (DateTime.Now.ToString("dd-MM-yyyy").Length == fechaNacimiento.ToString().Length);
        }
        public static bool ValidarAlturaCM(int alturaCM)
        {
            return (alturaCM > 0);
        }
    }
}

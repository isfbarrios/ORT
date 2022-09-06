using System;
using System.Collections.Generic;
using System.Text;

namespace Libraries.PracticoTres
{
    class Cliente
    {
        private int documento;
        private String nombre;
        private CuentaCorriente cuenta;

        public Cliente() {}
        public Cliente(int documento, String nombre, CodigoIso moneda)
        {
            this.documento = documento;
            this.nombre = nombre;
            if (!moneda.Equals(CodigoIso.NONE))
            {
                cuenta = new CuentaCorriente(documento, moneda);
            }
            else
            {
                cuenta = new CuentaCorriente();
            }
        }
        public int Documento
        {
            get { return this.documento; }
            set { this.documento = value; }
        }
        public String Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public CuentaCorriente Cuenta
        {
            get { return this.cuenta; }
            set { this.cuenta = value; }
        }
    }
}

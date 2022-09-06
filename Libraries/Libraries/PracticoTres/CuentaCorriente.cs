using System;
using System.Collections.Generic;
using System.Text;

namespace Libraries.PracticoTres
{
    class CuentaCorriente
    {
        private int numeroCta;
        private CodigoIso moneda;
        private float saldo;
        private int cantidadDepositos;
        private float costoTransaccion;

        public CuentaCorriente() {}
        public CuentaCorriente(int numeroCta, CodigoIso moneda)
        {
            this.numeroCta = numeroCta;
            this.moneda = moneda;
        }
        public float CostoTransaccion
        {
            get { return this.costoTransaccion; }
        }
        public CodigoIso Moneda
        {
            get { return this.moneda; }
        }
        public float Saldo
        {
            get { return this.saldo; }
        }
        public int CantidadDepositos
        {
            get { return this.cantidadDepositos; }
        }
        public bool ValidarMoneda(CodigoIso moneda)
        {
            bool isValid = false;
            if (moneda.Equals(CodigoIso.ARS) || moneda.Equals(CodigoIso.USD) || moneda.Equals(CodigoIso.UYU))
            {
                isValid = true;
            }
            return isValid;
        }
        public bool Depositar(float monto)
        {
            bool isValid = false;
            if (monto > 0.00f)
            {
                isValid = true;
            }
            return isValid;
        }
        public bool Retirar(float monto)
        {
            bool isValid = false;
            if (monto > 0.00f)
            {
                isValid = true;
            }
            return isValid;
        }
        public bool ValidarSaldo(float saldo)
        {
            bool isValid = false;
            if (this.saldo >= saldo)
            {
                isValid = true;
            }
            return isValid;
        }
        public bool ValidarCantidadDepositos()
        {
            bool isValid = false;
            if (this.cantidadDepositos > 3)
            {
                isValid = true;
            }
            return isValid;
        }
    }
}

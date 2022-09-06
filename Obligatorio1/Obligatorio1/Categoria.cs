using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio1
{
    class Categoria
    {
        private float minimoParaVIP;

        public float MinimoParaVip
        {
            get { return this.minimoParaVIP; }
            set { this.minimoParaVIP = value; }
        }

        public static TipoCategoria AsignarCategoria(float valorMercado)
        {
            return (valorMercado.CompareTo(
                new Categoria().minimoParaVIP) > 0 
                ? TipoCategoria.VIP 
                : TipoCategoria.ESTANDAR);
        }
    }
    public enum TipoCategoria
    {
        ESTANDAR,
        VIP
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class Categoria
    {
        private int minimoParaVIP;

        public int MinimoParaVip
        {
            get { return this.minimoParaVIP; }
            set { this.minimoParaVIP = value; }
        }

        /// <summary>
        /// Retorna la categoria correspondiente a un jugador determinado.
        /// </summary>
        private bool AltaSeleccion(Seleccion seleccion)
        {
            //Si el pais es valido y tiene al menos once jugadores, lo guardo
            if (!seleccion.Pais.EsPaisVacio() && seleccion.Jugadores.Count > +11)
            {
                Administradora.Instance.Selecciones.Add(seleccion);
            }
            return true;
        }
        public static TipoCategoria AsignarCategoria(Jugador j)
        {
            return (j.ValorMercado.CompareTo(
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

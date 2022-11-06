using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public class Categoria
    {
        public static bool setMinimoParaVip(int value)
        {
            int oldValue = Administradora.Instance.MinimoParaVIP;
            Administradora.Instance.MinimoParaVIP = value;
            //Retorno TRUE si el valor se actualizo, caso contrario, retorno FALSE
            return (Administradora.Instance.MinimoParaVIP != oldValue);
        }

        ///// <summary>
        ///// Retorna la categoria correspondiente a un jugador determinado.
        ///// </summary>
        //public static bool AltaSeleccion(Seleccion seleccion)
        //{
        //    //Si el pais es valido y tiene al menos once jugadores, lo guardo
        //    if (!seleccion.Pais.EsPaisVacio() && seleccion.Jugadores.Count > +11)
        //    {
        //        Administradora.Instance.Selecciones.Add(seleccion);
        //    }
        //    return true;
        //}
        public static TipoCategoria AsignarCategoria(Jugador j) => 
            (j.ValorMercado.CompareTo(Administradora.Instance.MinimoParaVIP) > 0 ? TipoCategoria.VIP : TipoCategoria.ESTANDAR);
    }
    public enum TipoCategoria
    {
        [Display(Name = "Estandar")]
        ESTANDAR,
        [Display(Name = "VIP")]
        VIP
    }
}

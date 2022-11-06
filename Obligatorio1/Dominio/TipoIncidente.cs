using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public enum TipoIncidente
    {
        [Display(Name = "Tarjeta amarilla")]
        TARJETA_AMARILLA,
        [Display(Name = "Tarjeta roja")]
        TARJETA_ROJA,
        [Display(Name = "Gol")]
        GOL
    }
}

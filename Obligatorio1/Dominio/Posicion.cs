using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public enum Posicion
    {
        [Display(Name = "Portero")]
        PORTERO,
        [Display(Name = "Defensa central")]
        DEFENSA_CENTRAL,
        [Display(Name = "Lateral derecho")]
        LATERAL_DERECHO,
        [Display(Name = "Lateral izquierdo")]
        LATERAL_IZQUIERDO,
        [Display(Name = "Pivote")]
        PIVOTE,
        [Display(Name = "Mediocentro")]
        MEDIOCENTRO,
        [Display(Name = "Interior derecho")]
        INTERIOR_DERECHO,
        [Display(Name = "Interior izquierdo")]
        INTERIOR_IZQUIERDO,
        [Display(Name = "Mediocentro ofensivo")]
        MEDIOCENTRO_OFENSIVO,
        [Display(Name = "Extremo derecho")]
        EXTREMO_DERECHO,
        [Display(Name = "Extremo izquierdo")]
        EXTREMO_IZQUIERDO,
        [Display(Name = "Mediapunta")]
        MEDIAPUNTA,
        [Display(Name = "Delantero centro")]
        DELANTERO_CENTRO
    }
}

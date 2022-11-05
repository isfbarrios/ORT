using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public enum Pie
    {
        [Display(Name = "No definido")]
        NO_DEFINIDO,
        [Display(Name = "Ambidiestro")]
        AMBIDIESTRO,
        [Display(Name = "Derecho")]
        DERECHO,
        [Display(Name = "Izquierdo")]
        IZQUIERDO
    }
}

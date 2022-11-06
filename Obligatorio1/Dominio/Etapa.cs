using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public enum Etapa
    {
        [Display(Name = "Octavos de final")]
        OCTAVOS,
        [Display(Name = "Cuartos de final")]
        CUARTOS,
        [Display(Name = "Semifinal")]
        SEMIFINAL,
        [Display(Name = "Final")]
        FINAL
    }
}

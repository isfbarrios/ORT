using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApp.Models
{
    public class JugadorModel
    {
        public Jugador Jugador { get; set; }
        public Pie Pie { get; set; }
        public Posicion Posicion { get; set; }
        public Moneda Moneda { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace webApp.Controllers
{
    public class IncidenteController : Controller
    {
        Administradora manager = Administradora.Instance;

        [HttpGet]
        public IActionResult Index()
        {
            return View(manager.Incidentes);
        }
        [HttpGet]
        public IActionResult IncidentePartido(int id)
        {
            Partido p = Partido.GetPartido(id);

            return View(p.Incidentes);
        }
        [HttpGet]
        public IActionResult IncidenteJugador(int id)
        {
            Jugador j = Jugador.GetJugador(id);

            return View(Incidente.GetIncidentes(j));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;

namespace webApp.Controllers
{
    public class IncidenteController : Controller
    {
        Administradora manager = Administradora.Instance;

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            return View(manager.Incidentes);
        }
        [HttpGet]
        public IActionResult IncidentePartido(int id)
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            Partido p = Partido.GetPartido(id);

            return View(p.Incidentes);
        }
        [HttpGet]
        public IActionResult IncidenteJugador(int id)
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            Jugador j = Jugador.GetJugador(id);

            return View(Incidente.GetIncidentes(j));
        }
    }
}

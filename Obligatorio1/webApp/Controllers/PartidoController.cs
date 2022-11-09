using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace webApp.Controllers
{
    public class PartidoController : Controller
    {
        Administradora manager = Administradora.Instance;

        [HttpGet]
        public IActionResult Index()
        {
            Administradora.PreLoad();
            return View(manager.Partidos);
        }
        [HttpGet]
        public IActionResult AltaJugador()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AltaJugador(Partido p)
        {
            if (p.Validar()) manager.Partidos.Add(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult IncidentePartido(int id)
        {
            Partido p = Partido.GetPartido(id);

            return View(Incidente.GetIncidentes(p));
        }
        [HttpGet]
        public IActionResult IncidenteJugador(int id)
        {
            Jugador j = Jugador.GetJugador(id);

            return View(Incidente.GetIncidentes(j));
        }
    }
}

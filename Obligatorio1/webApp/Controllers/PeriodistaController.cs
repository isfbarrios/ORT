using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace webApp.Controllers
{
    public class PeriodistaController : Controller
    {
        Administradora manager = Administradora.Instance;

        [HttpGet]
        public IActionResult Index()
        {
            return View(manager.Partidos);
        }
        [HttpGet]
        public IActionResult AltaJugador()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AltaJugador(Jugador j)
        {
            if (j.Validar()) manager.Jugadores.Add(j);
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace webApp.Controllers
{
    public class JugadorController : Controller
    {
        Administradora manager = Administradora.Instance;
        
        [HttpGet]
        public IActionResult Index()
        {
            Administradora.PreLoad();
            return View(manager.Jugadores);
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
        [HttpGet]
        public IActionResult Expulsados()
        {
            List<Incidente> incidentes = manager.Incidentes;
            List<Jugador> expulsados = Jugador.GetJugadoresExpulsados();
            return View(Jugador.GetJugadoresExpulsados());
        }
    }
}

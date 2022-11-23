using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Http;

namespace webApp.Controllers
{
    public class JugadorController : Controller
    {
        Administradora manager = Administradora.Instance;
        
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            return View(manager.Jugadores);
        }
        [HttpGet]
        public IActionResult AltaJugador()
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            return View();
        }
        [HttpPost]
        public IActionResult AltaJugador(Jugador j)
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            if (j.Validar()) manager.Jugadores.Add(j);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Expulsados()
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            return View(Jugador.GetJugadoresExpulsados());
        }
    }
}

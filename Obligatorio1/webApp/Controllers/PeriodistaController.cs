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
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            List<Periodista> retVal = new List<Periodista>();

            foreach (Usuario u in manager.Usuarios)
            {
                if (u.GetUserType() == "Periodista") retVal.Add((Periodista)u);
            }

            retVal.Sort();

            return View(retVal);
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
    }
}

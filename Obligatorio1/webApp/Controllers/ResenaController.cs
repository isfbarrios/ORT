using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace webApp.Controllers
{
    public class ResenaController : Controller
    {
        Administradora manager = Administradora.Instance;

        [HttpGet]
        public IActionResult Index(string mensaje)
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            ViewBag.Mensaje = mensaje;
            
            return View(manager.Resenas);
        }

        [HttpGet]
        public IActionResult MostrarResenas(List<Resena> resenas, string mensaje)
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            ViewBag.Mensaje = mensaje;
            resenas.Sort();

            return View(resenas);
        }

        [HttpPost]
        public IActionResult MostrarResenas(string id)
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            Periodista p = (Periodista)Periodista.GetUserById(int.Parse(id));

            if (p.ListaResenas.Count == 0) return RedirectToAction("index", new { mensaje = "No se encontraron reseñas para este periodista." });
            else
            {
                p.ListaResenas.Sort();

                return RedirectToAction("MostrarResenas", new { resenas = p.ListaResenas });
            }
        }

        [HttpGet]
        public IActionResult CrearResena(string mensaje)
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            ViewBag.Mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult CrearResena(string periodistaId, string titulo, string contenido, string partidoId)
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            bool retVal = false;
            Periodista periodista = (Periodista)Usuario.GetUserById(int.Parse(periodistaId));
            Partido partido = Partido.GetPartido(int.Parse(partidoId));

            if (periodista != null) retVal = Resena.CrearResena(periodista, titulo, contenido, partido);
            
            return RedirectToAction( (retVal ? "index" : "CrearResena"), 
                new { mensaje = (retVal ? "Reseña creada correctamente." 
                : "No se pudo crear la reseña. Intente nuevamente.") });
        }

        [HttpGet]
        public IActionResult VerResena(string id, string mensaje)
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            Resena r = Resena.GetResena(int.Parse(id));
            ViewBag.Mensaje = mensaje;
            return View(r);
        }
    }
}

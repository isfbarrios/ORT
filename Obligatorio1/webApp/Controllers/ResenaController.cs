using Microsoft.AspNetCore.Mvc;
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
            ViewBag.Mensaje = mensaje;
            return View(manager.Resenas);
        }

        [HttpPost]
        public IActionResult MostrarResena(int id)
        {
            Resena resena = Resena.GetResena(id);

            if (resena == null) return RedirectToAction("index", new { mensaje = "No se encontró la reseña." });

            return View(manager.Resenas);
        }

        [HttpGet]
        public IActionResult CrearResena(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult CrearResena(string periodistaId, string titulo, string contenido, string partidoId)
        {
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
            Resena r = Resena.GetResena(int.Parse(id));
            ViewBag.Mensaje = mensaje;
            return View(r);
        }
    }
}

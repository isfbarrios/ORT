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
    }
}

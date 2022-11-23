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
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            return View(manager.Partidos);
        }
        [HttpGet]
        public IActionResult PartidosCerrados(string dateFrom = "2022-11-20", string dateTo = "2022-12-18")
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            return View(Partido.GetPartidosFinalizados(dateFrom, dateTo));
        }
        [HttpPost]
        public IActionResult FiltrarPartidosCerrados(string dateFrom = "2022-11-20", string dateTo = "2022-12-18")
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            return RedirectToAction("PartidosCerrados", new { dateFrom, dateTo });
        }
        [HttpPost]
        public IActionResult Finalizar(string id, string viewReturn = "Index")
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            string retVal = "No se pudo finalizar el partido. Intente nuevamente";
            Partido p = Partido.GetPartido(int.Parse(id));
            bool finalizado = p.FinalizarPartido();

            if (finalizado) retVal = "Se finalizo el partido correctamente.";

            return RedirectToAction((finalizado ? viewReturn : "index"), new { id = id, mensaje = retVal }) ;
        }
        [HttpGet]
        public IActionResult VerPartido(string id, string mensaje)
        {
            if (HttpContext.Session.GetString("Rol") == null) return Redirect("/Login/");

            Partido partido = Partido.GetPartido(int.Parse(id));
            ViewBag.Mensaje = mensaje;

            return View(partido);
        }
    }
}

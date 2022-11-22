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
            return View(manager.Partidos);
        }
        [HttpGet]
        public IActionResult PartidosCerrados()
        {
            return View(Partido.GetPartidosFinalizados());
        }
        [HttpPost]
        public IActionResult Index(string dateFrom, string dateTo, string filter)
        {
            string retVal = "Index";
            if (filter == "0") retVal = "PartidosCerrados";

            return RedirectToAction(retVal);
        }
        [HttpPost]
        public IActionResult Finalizar(string id, string viewReturn = "Index")
        {
            string retVal = "No se pudo finalizar el partido. Intente nuevamente";
            Partido p = Partido.GetPartido(int.Parse(id));
            bool finalizado = p.FinalizarPartido();

            if (finalizado) retVal = "Se finalizo el partido correctamente.";

            return RedirectToAction((finalizado ? viewReturn : "index"), new { id = id, mensaje = retVal }) ;
        }
        [HttpGet]
        public IActionResult VerPartido(string id, string mensaje)
        {
            Partido partido = Partido.GetPartido(int.Parse(id));
            ViewBag.Mensaje = mensaje;

            return View(partido);
        }
    }
}

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
        public IActionResult Index(string filter)
        {
            string retVal = "Index";
            if (filter == "0") retVal = "PartidosCerrados";

            return RedirectToAction(retVal);
        }
    }
}

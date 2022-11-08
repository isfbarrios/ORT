using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace webApp.Controllers
{
    public class IncidenteController : Controller
    {
        Administradora manager = Administradora.Instance;
        public IActionResult Index()
        {
            return View(manager.Incidentes);
        }
        public IActionResult IncidentesPartido(int id)
        {
            Partido p = Partido.GetPartido(id);

            return View(Incidente.GetIncidentes(p));
        }
    }
}

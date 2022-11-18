using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace webApp.Controllers
{
    public class SeleccionController : Controller
    {
        Administradora manager = Administradora.Instance;
        [HttpGet]
        public ActionResult Index()
        {
            return View(manager.Selecciones);
        }
    }
}

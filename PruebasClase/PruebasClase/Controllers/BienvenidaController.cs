using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasClase.Controllers
{
    public class BienvenidaController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Saludo = "Hola Mundo!";
            return View();
        }
    }
}

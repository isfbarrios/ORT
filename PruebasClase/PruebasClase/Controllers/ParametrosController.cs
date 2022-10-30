using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasClase.Controllers
{
    public class ParametrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProbarParametro(int id)
        {
            ViewBag.Mensaje01 = "Recibido el valor " + id.ToString();
            return View("Index");
        }
        public IActionResult ProbarParametroConOtroNombre(int? edad)
        {
            if (edad != null)
            {
                ViewBag.Mensaje02 = "Recibido el valor " + edad.ToString();
            }
            else
            {
                ViewBag.Mensaje02 = "No se recibió ningún valor ";
            }
            return View("Index");
        }
    }
}

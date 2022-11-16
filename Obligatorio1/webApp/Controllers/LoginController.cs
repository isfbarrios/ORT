using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace webApp.Controllers
{
    public class LoginController : Controller
    {
        Administradora manager = Administradora.Instance;

        [HttpGet]
        public ActionResult Index(string mensaje)
        {
            if (!Administradora.Instance.Loaded) Administradora.PreLoad();
            ViewBag.Mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string user, string pass)
        {
            bool sessionLoaded = false;
            if (Periodista.GetPeriodista(user) != null)
            {
                HttpContext.Session.SetString("Nombre", user);
                HttpContext.Session.SetString("Rol", "Periodista");
                sessionLoaded = true;
            }
            if (Operador.GetPeriodista(user) != null)
            {
                HttpContext.Session.SetString("Nombre", user);
                HttpContext.Session.SetString("Rol", "Operador");

            }
            sessionLoaded = HttpContext.Session.GetString("Nombre") != null;

            if (sessionLoaded) Redirect("~/Home");

            return RedirectToAction("index", new { mensaje = "Usuario o contraseña incorrecta." });
        }
        [HttpPost]
        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View();
        }
    }
}

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
            Usuario usuario = Administradora.GetUsuario(user);

            if (usuario != null && usuario.Password == pass.Trim())
            {
                HttpContext.Session.SetString("Id", usuario.Id.ToString());
                HttpContext.Session.SetString("Nombre", user);
                HttpContext.Session.SetString("Rol", usuario.GetUserType());
            }
            
            sessionLoaded = (HttpContext.Session.GetString("Nombre") != null);

            if (sessionLoaded) return Redirect("~/Home");

            return RedirectToAction("index", new { mensaje = "Usuario o contraseña incorrecta." });
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home");
        }

        [HttpGet]
        public ActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrarse(string nombre, string apellido, string mail, string pass)
        {
            Periodista periodista = new Periodista(nombre, apellido, mail, pass);

            return RedirectToAction("index",
                Periodista.AltaPeriodista(periodista) ?
                new { mensaje = "Perfil periodista creado correctamente." }
                : new { mensaje = "Alguno de los datos no son correctos, vuelva a intentar." });
        }
    }
}

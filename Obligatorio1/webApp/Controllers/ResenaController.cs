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
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApp.Controllers
{
    public class SeleccionController : Controller
    {
        // GET: SeleccionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SeleccionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SeleccionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SeleccionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SeleccionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SeleccionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SeleccionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SeleccionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

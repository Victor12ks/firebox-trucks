using FireboxTrucks.Web.DataContext;
using FireboxTrucks.Web.Models;
using FireboxTrucks.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FireboxTrucks.Web.Controllers
{
    public class ModeloController : Controller
    {
        private readonly FireboxTrucksContext _context;
        public ModeloController(FireboxTrucksContext context)
        {
            _context = context;
        }
        // GET: ModeloController
        public ActionResult Index()
        {
            var modelos = new ModeloService(_context).ObterModelos();
            return View(modelos);
        }

        // GET: ModeloController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ModeloController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModeloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Modelo model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var modelo = new ModeloService(_context).IncluirModelo(model);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                var ok = ex;
                return View();
            }
            return View(model);
        }

        // GET: ModeloController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ModeloController/Edit/5
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

        // GET: ModeloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ModeloController/Delete/5
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

using FireboxTrucks.Web.DataContext;
using FireboxTrucks.Web.Mock;
using FireboxTrucks.Web.Models;
using FireboxTrucks.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace FireboxTrucks.Web.Controllers
{
    public class CaminhaoController : Controller
    {
        private readonly FireboxTrucksContext _context;
        public CaminhaoController(FireboxTrucksContext context)
        {
            _context = context;
        }
        // GET: CaminhaoController
        public ActionResult Index()
        {
            var caminhaos = _context.Caminhao.ToList();
            var mock = ModeloMock.ObterModelos();
            caminhaos.Add(new Caminhao() { AnoModelo = 2022, Descricao = "teste", Modelo = mock[0], ID = 12, ModeloID = 1 });
            return View(caminhaos);
        }

        // GET: CaminhaoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CaminhaoController/Create
        public IActionResult Create()
        {
            var mock = ModeloMock.ObterModelos();
            ViewData["ModeloID"] = new SelectList(mock, "ID", "Nome");
            return View();
        }

        // POST: CaminhaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Caminhao model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var caminhao = new CaminhaoService(_context).IncluirCaminhao(model);
                    return RedirectToAction("Index");
                }
                var mock = ModeloMock.ObterModelos();
                ViewData["ModeloID"] = new SelectList(mock, "ID", "Nome");
            }
            catch (Exception ex)
            {
                var ok = ex;
                return View();
            }
            return View(model);
        }

        // GET: CaminhaoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CaminhaoController/Edit/5
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

        // GET: CaminhaoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CaminhaoController/Delete/5
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

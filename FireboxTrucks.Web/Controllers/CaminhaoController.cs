using FireboxTrucks.Web.DataContext;
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
            var caminhoes = new CaminhaoService(_context).ObterCaminhoes();
            return View(caminhoes);
        }

        // GET: CaminhaoController/Details/5
        public ActionResult Details(int id)
        {
            var caminhao = new CaminhaoService(_context).ObterCaminhao(id);
            return View(caminhao);
        }

        // GET: CaminhaoController/Create
        public IActionResult Create()
        {
            var modelos = new ModeloService(_context).ObterModelos().ToList().Where(x => new Caminhao().ObterModelosPermitidos().Contains(x.Nome.ToUpper()));
            ViewData["ModeloID"] = new SelectList(modelos, "ID", "Nome");
            var caminhao = new Caminhao();
            return View(caminhao);
        }

        // POST: CaminhaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Caminhao model)
        {
            try
            {
                var modelos = new ModeloService(_context).ObterModelos().ToList().Where(x => model.ObterModelosPermitidos().Contains(x.Nome.ToUpper()));
                model.Modelo = modelos.FirstOrDefault(x => x.ID == model.ModeloID);
                if (ModelState.IsValid)
                {
                    var caminhao = new CaminhaoService(_context).IncluirCaminhao(model);
                    if (caminhao == null)
                        return NotFound();
                    else
                        return RedirectToAction("Index");
                }
                ViewData["ModeloID"] = new SelectList(modelos, "ID", "Nome");
            }
            catch
            {
                return View(model);
            }
            return View(model);
        }

        // GET: CaminhaoController/Edit/5
        public ActionResult Edit(int id)
        {
            var modelos = new ModeloService(_context).ObterModelos().ToList().Where(x => new Caminhao().ObterModelosPermitidos().Contains(x.Nome.ToUpper()));
            ViewData["ModeloID"] = new SelectList(modelos, "ID", "Nome");
            var caminhao = new CaminhaoService(_context).ObterCaminhao(id);
            if (caminhao == null)
                return NotFound();

            return View(caminhao);
        }

        // POST: CaminhaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Caminhao model)
        {
            try
            {
                var modelos = new ModeloService(_context).ObterModelos().ToList().Where(x => model.ObterModelosPermitidos().Contains(x.Nome.ToUpper()));
                model.Modelo = modelos.FirstOrDefault(x => x.ID == model.ModeloID);
                var caminhao = new CaminhaoService(_context).AlterarCaminhao(model);
                if (caminhao == null)
                    return NotFound();

                return View(caminhao);
            }
            catch
            {
                return View();
            }
        }

        // GET: CaminhaoController/Delete/5
        public IActionResult Delete(int id)
        {
            var caminhao = new CaminhaoService(_context).ObterCaminhao(id);
            if (caminhao == null)
                return NotFound();

            return View(caminhao);
        }

        // POST: CaminhaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var caminhao = new CaminhaoService(_context).ExcluirCaminhao(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

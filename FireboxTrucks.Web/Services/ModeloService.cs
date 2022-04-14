using FireboxTrucks.Web.DataContext;
using FireboxTrucks.Web.Models;
using FireboxTrucks.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FireboxTrucks.Web.Services
{
    public class ModeloService : IModeloService
    {
        private readonly FireboxTrucksContext _context;
        public ModeloService(FireboxTrucksContext context)
        {
            _context = context;
        }

        public Modelo IncluirModelo(Modelo modelo)
        {
            if (modelo == null)
                return null;
            if (modelo.ValidarModelo())
            {
                _context.Add(modelo);
                _context.SaveChanges();
                return modelo;
            }
            return null;
        }
        public Modelo ObterModelo(int id)
        {
            return _context.Modelo.Where(c => c.ID == id).FirstOrDefault();
        }
        public List<Modelo> ObterModelos()
        {
            var modelos = _context.Modelo.ToList();
            if (modelos == null || modelos.Count <= 0) modelos = PreencherModelosBase();
            return modelos;
        }
        private List<Modelo> PreencherModelosBase()
        {
            _context.Modelo.AddRange(new Modelo() { Descricao = "Forward control Medium Xtreme", Nome = "FMX" },
            new Modelo() { Descricao = "Forward control High entry", Nome = "FH" },
            new Modelo() { Descricao = "Forward control Medium height cab", Nome = "FM" });

            _context.SaveChanges();
            
            return _context.Modelo.ToList();
        }
    }
}

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
            var modelo = _context.Modelo.Where(c => c.ID == id).FirstOrDefault();
            return modelo;
        }
        public List<Modelo> ObterModelos()
        {
            var modelos = _context.Modelo.ToList();
            return modelos;
        }
    }
}

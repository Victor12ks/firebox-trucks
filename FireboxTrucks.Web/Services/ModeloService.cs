using FireboxTrucks.Web.DataContext;
using FireboxTrucks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FireboxTrucks.Web.Services.Interfaces
{
    public class ModeloService : IModeloService
    {
        private readonly FireboxTrucksContext _context;
        public ModeloService(FireboxTrucksContext context)
        {
            _context = context;
        }

        public Modelo AlterarModelo(Modelo modelo)
        {
            throw new NotImplementedException();
        }

        public Modelo ExcluirModelo(int id)
        {
            throw new NotImplementedException();
        }

        public Modelo IncluirModelo(Modelo modelo)
        {
            throw new NotImplementedException();
        }

        public Modelo ObterModelo(int id)
        {
            throw new NotImplementedException();
        }
    }
}

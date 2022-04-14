using FireboxTrucks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FireboxTrucks.Web.Services.Interfaces
{
    interface IModeloService
    {
        public List<Modelo> ObterModelos();
        public Modelo ObterModelo(int id);
        public Modelo IncluirModelo(Modelo modelo);
    }
}

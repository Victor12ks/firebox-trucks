using FireboxTrucks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FireboxTrucks.Web.Services.Interfaces
{
    interface IModeloService
    {
        public Modelo ObterModelo(int id);
        public Modelo IncluirModelo(Modelo modelo);
        public Modelo ExcluirModelo(int id);
        public Modelo AlterarModelo(Modelo modelo);
    }
}

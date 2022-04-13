using FireboxTrucks.Web.DataContext;
using FireboxTrucks.Web.Models;
using FireboxTrucks.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FireboxTrucks.Web.Services
{
    public class CaminhaoService : ICaminhaoService
    {
        private readonly FireboxTrucksContext _context;
        public CaminhaoService(FireboxTrucksContext context)
        {
            _context = context;
        }

        public Caminhao ObterCaminhao(int id)
        {
            var caminhao = _context.Caminhao
                             .Include(c => c.Modelo)
                 .Where(c => c.ID == id)
                 .FirstOrDefault();
            return caminhao;
        }

        public Caminhao IncluirCaminhao(Caminhao caminhao)
        {
            if (caminhao.ValidarCaminhao())
            {
                _context.Add(caminhao);
                _context.SaveChanges();
                return caminhao;
            }
            return null;
        }

        public Caminhao ExcluirCaminhao(int id)
        {
            var caminhao = ObterCaminhao(id);
            _context.Caminhao.Remove(caminhao);
            _context.SaveChanges();
            return caminhao;
        }

        public Caminhao AlterarCaminhao(Caminhao caminhao)
        {
            throw new System.NotImplementedException();
        }
    }
}

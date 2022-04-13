﻿using FireboxTrucks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FireboxTrucks.Web.Services.Interfaces
{
    interface ICaminhaoService
    {
        public Caminhao ObterCaminhao(int id);
        public Caminhao IncluirCaminhao(Caminhao caminhao);
        public Caminhao ExcluirCaminhao(int id);
        public Caminhao AlterarCaminhao(Caminhao caminhao);
    }
}

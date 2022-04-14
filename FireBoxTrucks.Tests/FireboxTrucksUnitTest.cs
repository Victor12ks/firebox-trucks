using FireboxTrucks.Web.DataContext;
using FireboxTrucks.Web.Models;
using FireboxTrucks.Web.Services;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace FireBoxTrucks.Tests
{
    public class FireboxTrucksUnitTest
    {
        #region [+] Propriedades
        private ModeloService _modeloService;
        private CaminhaoService _caminhaoService;
        public static DbContextOptions<FireboxTrucksContext> dbContextOptions { get; }
        public static string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=FireBoxTest;Trusted_Connection=True;MultipleActiveResultSets=true";

        static FireboxTrucksUnitTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<FireboxTrucksContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public FireboxTrucksUnitTest()
        {
            var context = new FireboxTrucksContext(dbContextOptions);
            MockRepository db = new MockRepository();
            db.Iniciar(context);

            _caminhaoService = new CaminhaoService(context);
            _modeloService = new ModeloService(context);
        }
        #endregion

        #region [+] Caminh�o

        [Fact(DisplayName = "Incluir Caminh�o Valido")]
        [Trait("Caminh�o", "Incluir")]
        public void Incluir_Caminhao_Valido()
        {
            var model = new Caminhao() { AnoModelo = 2023, Descricao = "Teste test", ModeloID = 1 };
            var caminhao = _caminhaoService.IncluirCaminhao(model);
            Assert.NotNull(caminhao);
        }

        [Fact(DisplayName = "Incluir Caminh�o Ano do Modelo Invalido")]
        [Trait("Caminh�o", "Incluir")]
        public void Incluir_Caminhao_AnoModelo_Invalido()
        {
            var model = new Caminhao() { AnoModelo = 2020, Descricao = "Teste test", ModeloID = 1 };
            var caminhao = _caminhaoService.IncluirCaminhao(model);
            Assert.Null(caminhao);
        }

        [Fact(DisplayName = "Incluir Caminh�o Modelo Invalido")]
        [Trait("Caminh�o", "Incluir")]
        public void Incluir_Caminhao_Modelo_Invalido()
        {
            var model = new Caminhao() { AnoModelo = 2023, Descricao = "Teste test", ModeloID = 3 };
            var caminhao = _caminhaoService.IncluirCaminhao(model);
            Assert.Null(caminhao);
        }

        [Fact(DisplayName = "Obter Caminh�o Valido")]
        [Trait("Caminh�o", "Obter")]
        public void Obter_Caminhao_Valido()
        {
            var caminhao = _caminhaoService.ObterCaminhao(2);
            Assert.NotNull(caminhao);
        }
        [Fact(DisplayName = "Obter Caminh�o Invalido")]
        [Trait("Caminh�o", "Obter")]
        public void Obter_Caminhao_Invalido()
        {
            var caminhao = _caminhaoService.ObterCaminhao(50);
            Assert.Null(caminhao);
        }
        [Fact(DisplayName = "Alterar Caminh�o Valido")]
        [Trait("Caminh�o", "Alterar")]
        public void Alterar_Caminhao_Valido()
        {
            var model = _caminhaoService.ObterCaminhao(2);
            var caminhao = _caminhaoService.AlterarCaminhao(model);
            Assert.NotNull(caminhao);
        }
        [Fact(DisplayName = "Alterar Caminh�o Invalido")]
        [Trait("Caminh�o", "Alterar")]
        public void Alterar_Caminhao_Invalido()
        {
            var caminhao = _caminhaoService.AlterarCaminhao(null);
            Assert.Null(caminhao);
        }
        [Fact(DisplayName = "Excluir Caminh�o Valido")]
        [Trait("Caminh�o", "Excluir")]
        public void Excluir_Caminhao_Valido()
        {
            var caminhao = _caminhaoService.ExcluirCaminhao(3);
            Assert.NotNull(caminhao);
        }
        [Fact(DisplayName = "Excluir Caminh�o Invalido")]
        [Trait("Caminh�o", "Excluir")]
        public void Excluir_Caminhao_Invalido()
        {
            var caminhao = _caminhaoService.ExcluirCaminhao(new Random().Next(100, 1000000));
            Assert.Null(caminhao);
        }
        [Fact(DisplayName = "Obter Caminh�es Valido")]
        [Trait("Caminh�es", "Obter")]
        public void Obter_Caminhoes_Valido()
        {
            var caminhoes = _caminhaoService.ObterCaminhoes();
            Assert.NotNull(caminhoes);
        }
        #endregion

        #region [+] Modelo

        [Fact(DisplayName = "Incluir Modelo Valido")]
        [Trait("Modelo", "Incluir")]
        public void Incluir_Modelo_Valido()
        {
            var model = new Modelo() { Descricao = "Novo Modelo", Nome = "MXRF" };
            var modelo = _modeloService.IncluirModelo(model);
            Assert.NotNull(modelo);
        }
        [Fact(DisplayName = "Incluir Modelo Invalido")]
        [Trait("Modelo", "Incluir")]
        public void Incluir_Modelo_Invalido()
        {
            var modelo = _modeloService.IncluirModelo(null);
            Assert.Null(modelo);
        }
        [Fact(DisplayName = "Incluir Modelo Invalido Sem Nome")]
        [Trait("Modelo", "Incluir")]
        public void Incluir_Modelo_SemNome_Invalido()
        {
            var model = new Modelo() { Descricao = "Novo Modelo", Nome = "" };
            var modelo = _modeloService.IncluirModelo(model);
            Assert.Null(modelo);
        }
        [Fact(DisplayName = "Validar Modelo")]
        [Trait("Caminh�es", "Obter")]
        public void Validar_Modelo_Valido()
        {
            var model = new Modelo() { Descricao = "Novo Modelo", Nome = "MXRF" };
            Assert.True(model.ValidarModelo());
        }
        [Fact(DisplayName = "Validar Modelo Invalido")]
        [Trait("Caminh�es", "Obter")]
        public void Validar_Modelo_Invalido()
        {
            var model = new Modelo() { Descricao = "", Nome = "MXRF" };
            Assert.False(model.ValidarModelo());
        }
        #endregion
    }
}

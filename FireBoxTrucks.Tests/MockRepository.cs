using FireboxTrucks.Web.DataContext;
using FireboxTrucks.Web.Models;

namespace FireBoxTrucks.Tests
{
    public class MockRepository
    {
        public MockRepository()
        {

        }
        public void Iniciar(FireboxTrucksContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var m1 = new Modelo() { Nome = "FH", Descricao = "modelo fh" };
            var m2 = new Modelo() { Nome = "FM", Descricao = "modelo fm" };
            var m3 = new Modelo() { Nome = "FMX", Descricao = "modelo fmx" };
            //context.Modelo.Add(m1);
            //context.Modelo.Add(m2);
            //context.Modelo.Add(m3);
            //context.SaveChanges();


            context.Modelo.AddRange(
                new Modelo() { Nome = "FH", Descricao = "modelo fh" },
                new Modelo() { Nome = "FM", Descricao = "modelo fm" },
                new Modelo() { Nome = "FMX", Descricao = "modelo fmx" },
                new Modelo() { Nome = "VM", Descricao = "modelo vm" }
            );
            context.SaveChanges();

            context.Caminhao.AddRange(
               new Caminhao() { AnoModelo = 2023, Descricao = "Teste test 3", ModeloID = 1 },
               new Caminhao() { AnoModelo = 2023, Descricao = "Teste test 2", ModeloID = 2 },
               new Caminhao() { AnoModelo = 2022, Descricao = "Teste test 1", ModeloID = 2 },
               new Caminhao() { AnoModelo = 2022, Descricao = "Teste test 1", ModeloID = 2 }
           );

            //var c1 = new Caminhao() { AnoModelo = 2023, Descricao = "Teste test 3", ModeloID = 1 };
            //var c2 = new Caminhao() { AnoModelo = 2023, Descricao = "Teste test 2", ModeloID = 1 };
            //var c3 = new Caminhao() { AnoModelo = 2022, Descricao = "Teste test 1", ModeloID = 1 };
            //context.Caminhao.Add(c1);
            //context.Caminhao.Add(c2);
            //context.Caminhao.Add(c3);


            context.SaveChanges();
        }
    }
}

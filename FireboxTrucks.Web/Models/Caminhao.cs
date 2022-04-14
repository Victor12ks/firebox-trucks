using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FireboxTrucks.Web.Models
{
    public class Caminhao
    {
        public Caminhao()
        {
            AnoFabricacao = DateTime.Now.Year;
        }

        [Key]
        public int ID { get; set; }

        public int ModeloID { get; set; }

        [Display(Name = "Ano de Fabricação")]
        [ReadOnly(true)]
        [Editable(false, AllowInitialValue = false)]
        public int AnoFabricacao { get; private set; }

        [Display(Name = "Ano do Modelo")]
        [Required(ErrorMessage = "O campo Ano do Modelo deve ser informado")]
        [RegularExpression(@"^([0-9]{4})$", ErrorMessage = "Ano do Modelo em formato inválido")]
        public int AnoModelo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public Modelo Modelo { get; set; }


        private bool ValidarModelo() => ObterModelosPermitidos().Contains(this.Modelo.Nome.ToUpper());
        private bool ValidarAnoModelo() => this.AnoFabricacao == DateTime.Now.Year;
        private bool ValidarAnoFabricao() => this.AnoModelo == DateTime.Now.Year || this.AnoModelo == (DateTime.Now.Year + 1);
        public bool ValidarCaminhao() => ValidarModelo() && ValidarAnoModelo() && ValidarAnoFabricao();
        public List<string> ObterModelosPermitidos() => new List<string> { "FM", "FH" };

    }
}

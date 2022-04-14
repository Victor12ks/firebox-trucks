using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FireboxTrucks.Web.Models
{
    public class Modelo
    {

        public Modelo()
        {

        }

        [Key]
        public int ID { get; private set; }
        [Required]
        [Display(Name = "Modelo")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public bool ValidarNome() => !string.IsNullOrEmpty(this.Nome);
        public bool ValidarDescricao() => !string.IsNullOrEmpty(this.Descricao);
        public bool ValidarModelo() => ValidarNome() && ValidarDescricao();
    }
}

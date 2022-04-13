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
        public Modelo(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        [Key]
        public int ID { get; private set; }
        [Required]
        [Display(Name = "Modelo")]
        public string Nome { get; private set; }
        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; private set; }
    }
}

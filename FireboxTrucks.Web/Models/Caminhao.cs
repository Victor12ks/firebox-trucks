using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        [MaxLength(4)]
        [Display(Name = "Ano de Fabricação")]
        [Required(ErrorMessage = "O campo Ano de Fabricação deve ser informado")]
        [DataType(DataType.Text, ErrorMessage = "Ano de Fabricação em formato inválido")]
        public int AnoFabricacao { get; set; }

        [MaxLength(4)]
        [Display(Name = "Ano do Modelo")]
        [Required(ErrorMessage = "O campo Ano do Modelo deve ser informado")]
        [DataType(DataType.Text, ErrorMessage = "Ano do Modelo em formato inválido")]
        public int AnoModelo { get; set; }

        public Modelo Modelo { get; set; }
    }
}

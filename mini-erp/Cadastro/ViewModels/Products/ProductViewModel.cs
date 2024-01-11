using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cadastro.ViewModels.Products
{
    public class ProductViewModel
    {
        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é requerido.")]
        public string Name { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O valor é requerido.")]
        public double Value { get; set; }

        [Display(Name = "Disponivel")]
        public bool Active { get; set; }

        [Display(Name = "Cliente")]
        public int IdClient { get; set; }

        [Display(Name = "Cliente")]
        public ClientViewModel Client { get; set; }
    }
}

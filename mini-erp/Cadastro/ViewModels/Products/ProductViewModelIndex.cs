using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Cadastro.ViewModels.Products
{
    public class ProductViewModelIndex
    {
        [Key]
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código é requerido.")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é requerido.")]
        public string Name { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "O cliente é requerido.")]
        public ClientViewModel Client { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O valor é requerido.")]
        public double Value { get; set; }

        [Display(Name = "Disponivel")]
        [Required(ErrorMessage = "O campo 'Disponivel' é requerido.")]
        public bool Available { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
    }
}

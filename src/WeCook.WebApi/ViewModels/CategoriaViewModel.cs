using System.ComponentModel.DataAnnotations;

namespace WeCook.WebApi.ViewModels
{
    public class CategoriaViewModel
    {
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter de 3 a 20 caracteres!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter de 3 a 20 caracteres!")]
        public string Nome { get; set; }
    }
}

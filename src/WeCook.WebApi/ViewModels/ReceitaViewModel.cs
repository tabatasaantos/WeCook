using System.ComponentModel.DataAnnotations;
using WeCook.Domain;

namespace WeCook.WebApi.ViewModels
{
    public class ReceitaViewModel
    {
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter de 3 a 20 caracteres!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter de 3 a 20 caracteres!")]
        public string Ingredientes { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(240, ErrorMessage = "Este campo deve conter de 3 a 240 caracteres!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter de 3 a 240 caracteres!")]
        public string ModoPreparo { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(240, ErrorMessage = "Este campo deve conter de 3 a 240 caracteres!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter de 3 a 240 caracteres!")]
        public decimal TempoPreparo { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(5, ErrorMessage = "Este campo deve conter de 3 a 5 caracteres!")]
        [MinLength(2, ErrorMessage = "Este campo deve conter de 3 a 5 caracteres!")]
        public int Rendimento { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(5, ErrorMessage = "Este campo deve conter de 3 a 5 caracteres!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter de 3 a 5 caracteres!")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}

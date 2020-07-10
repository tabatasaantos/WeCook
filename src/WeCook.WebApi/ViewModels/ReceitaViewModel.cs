using System;
using System.ComponentModel.DataAnnotations;
using WeCook.Domain;
using WeCook.Domain.Base;

namespace WeCook.WebApi.ViewModels
{
    public class ReceitaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo {0} é obrigatório!")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter de {3} a {20} caracteres!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter de {3} a {20} caracteres!")]
        public string Nome { get; set; }
        //[Required(ErrorMessage = "Este campo {0} é obrigatório!")]
        //[StringLength(600, ErrorMessage = "Este campo {0} deve conter de {3} a {600} caracteres!", MinimumLength = 3)]
        public string Ingredientes { get; set; }
        //[Required(ErrorMessage = "Este campo {0} é obrigatório!")]
        //[StringLength(600, ErrorMessage = "Este campo {0} deve conter de {3} a {600} caracteres!", MinimumLength = 3)]
        public string ModoPreparo { get; set; }
        //[Required(ErrorMessage = "Este campo {0} é obrigatório!")]
        //[StringLength(5, ErrorMessage = "Este campo deve conter de {1} a {5} caracteres!", MinimumLength = 1)]
        public decimal TempoPreparoEmMin { get; set; }

        public Guid CategoriaId { get; set; }
    }
}

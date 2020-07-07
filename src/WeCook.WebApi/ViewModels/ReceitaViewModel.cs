using System;
using System.ComponentModel.DataAnnotations;
using WeCook.Domain;
using WeCook.Domain.Base;

namespace WeCook.WebApi.ViewModels
{
    public class ReceitaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        //[Required(ErrorMessage = "Este campo é obrigatório!")]
        //[MinLength(3, ErrorMessage = "Este campo deve conter de 3 a 20 caracteres!")]
        public string Ingredientes { get; set; }
        //[Required(ErrorMessage = "Este campo é obrigatório!")]
        //[MinLength(3, ErrorMessage = "Este campo deve conter de 3 a 240 caracteres!")]
        public string ModoPreparo { get; set; }
        //[Required(ErrorMessage = "Este campo é obrigatório!")]
        //[MinLength(3, ErrorMessage = "Este campo deve conter de 3 a 240 caracteres!")]
        public decimal TempoPreparoEmMin { get; set; }
        //[Required(ErrorMessage = "Este campo é obrigatório!")]
        //[MinLength(1, ErrorMessage = "Este campo deve conter de 3 a 5 caracteres!")]

        public Guid CategoriaId { get; set; }
    }
}

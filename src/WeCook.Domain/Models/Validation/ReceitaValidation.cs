using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeCook.Domain.Models.Validation
{
    public class ReceitaValidation : AbstractValidator<Receita>
    {
        public ReceitaValidation()
        {
            RuleFor(r => r.Nome)
           .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido").Length(3, 30)
           .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(r => r.Ingredientes)
           .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido").Length(3, 600)
           .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(r => r.ModoPreparo)
           .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido").Length(3, 600)
           .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}

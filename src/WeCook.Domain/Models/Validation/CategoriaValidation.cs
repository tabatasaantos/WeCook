using FluentValidation;

namespace WeCook.Domain.Models.Validation
{
    public class CategoriaValidation : AbstractValidator<Categoria>
    {
        public CategoriaValidation()
        {
            RuleFor(c => c.Nome)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido").Length(3, 20)
               .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}

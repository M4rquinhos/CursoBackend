using CursoBackend.DTOs;
using FluentValidation;

namespace CursoBackend.Validators
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe medir de 2 a 20 caracteres");
            RuleFor(x => x.BrandId).NotNull().WithMessage(x => "La marca es obligatoria");
            RuleFor(x => x.BrandId).GreaterThan(0).WithMessage(x => "Error con el valor de la marca");
            RuleFor(x => x.Alcohol).GreaterThan(0).WithMessage(x => "El {PropertyName} debe ser mayor a 0");
        }
    }
}

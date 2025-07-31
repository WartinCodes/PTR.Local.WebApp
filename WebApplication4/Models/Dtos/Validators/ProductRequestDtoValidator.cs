using FluentValidation;
using WebApplication4.Models.Dtos.Requests;

namespace WebApplication4.Models.Dtos.Validators
{
    public class ProductRequestDtoValidator : AbstractValidator<ProductRequestDto>
    {
        public ProductRequestDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("Máximo 100 caracteres");

            RuleFor(x => x.Price)
                .InclusiveBetween(1, 1000000)
                .WithMessage("El precio debe ser mayor a 0");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Debe indicar una categoría");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("La cantidad no puede ser negativa");
        }
    }
}



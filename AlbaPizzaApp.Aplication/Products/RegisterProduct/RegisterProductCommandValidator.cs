using FluentValidation;

namespace AlbaPizzaApp.Application.Products.RegisterProduct;
internal sealed class RegisterProductCommandValidator : AbstractValidator<RegisterProductCommand>
{
    public RegisterProductCommandValidator()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Descripción del producto requerida")
            .MinimumLength(3).WithMessage("Descripción del producto debe ser mínimo 3 caracteres")
            .MaximumLength(50).WithMessage("Descripción del producto debe ser máximo  50 caracteres");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(1).WithMessage("El precio mínimo del producto debe ser 1")
            .PrecisionScale(18, 2, true).WithMessage("El precio debe tener una precisión máxima de 18 dígitos y 2 decimales");

        RuleFor(x => x.TaxType)
            .NotEmpty().WithMessage("Tipo de impuesto del producto es requerido");
    }
}

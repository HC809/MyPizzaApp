using FluentValidation;

namespace AlbaPizzaApp.Application.Products.UpdateProduct;
internal sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("El ID del producto es requerido.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Descripción del producto es requerida.")
            .MinimumLength(3).WithMessage("Descripción del producto debe ser mínimo 3 caracteres.")
            .MaximumLength(50).WithMessage("Descripción del producto debe ser máximo  50 caracteres.");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Precio del producto es requerido.")
            .GreaterThanOrEqualTo(1).WithMessage("El precio mínimo del producto debe ser 1.")
            .PrecisionScale(18, 2, true).WithMessage("El precio debe tener una precisión máxima de 18 dígitos y 2 decimales.");

        RuleFor(x => x.TaxType)
            .NotEmpty().WithMessage("El tipo de impuesto del producto es requerido.");
    }
}

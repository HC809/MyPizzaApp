using FluentValidation;

namespace AlbaPizzaApp.Application.Orders.RegisterOrder;
internal sealed class RegisterOrderCommandValidator : AbstractValidator<RegisterOrderCommand>
{
    public RegisterOrderCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("El ID del cliente es obligatorio.");

        RuleFor(x => x.OrderDate)
            .NotEmpty().WithMessage("La fecha del pedido es obligatoria.");

        RuleForEach(x => x.OrderDetails)
            .SetValidator(new OrderDetailCommandValidator());
    }
}

internal sealed class OrderDetailCommandValidator : AbstractValidator<OrderDetailCommand>
{
    public OrderDetailCommandValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("El ID del producto es obligatorio.");

        RuleFor(x => x.TaxType)
            .IsInEnum().WithMessage("El tipo de impuesto es inválido.");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("La cantidad debe ser mayor que 0.");

        RuleFor(x => x.UnitPrice)
            .GreaterThanOrEqualTo(0).WithMessage("El precio unitario debe ser mayor o igual a 0.");
    }
}


using FluentValidation;

namespace AlbaPizzaApp.Application.OrderDetails.UpdateOrderDetail;
internal sealed class UpdateOrderDetailCommandValidator : AbstractValidator<UpdateOrderDetailCommand>
{
    public UpdateOrderDetailCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("El ID del detalle del pedido es obligatorio.");

        RuleFor(x => x.OrderId)
            .NotEmpty().WithMessage("El ID del pedido es obligatorio.");

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


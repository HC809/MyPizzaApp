using AlbaPizzaApp.Application.Orders.RegisterOrder;
using FluentValidation;

namespace AlbaPizzaApp.Application.Orders.UpdateOrder;
internal sealed class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("El ID del pedido es obligatorio.");

        RuleFor(x => x.AddressId)
            .NotEmpty().WithMessage("El ID de la dirección es obligatorio.");

        RuleFor(x => x.OrderDate)
            .NotEmpty().WithMessage("La fecha del pedido es obligatoria.");

        RuleForEach(x => x.OrderDetails)
            .SetValidator(new OrderDetailCommandValidator());
    }
}


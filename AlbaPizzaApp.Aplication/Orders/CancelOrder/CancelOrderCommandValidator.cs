using FluentValidation;

namespace AlbaPizzaApp.Application.Orders.CancelOrder;
internal sealed class CancelOrderCommandValidator : AbstractValidator<CancelOrderCommand>
{
    public CancelOrderCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("El ID del pedido es obligatorio.");

        RuleFor(x => x.CancelDate)
            .NotEmpty().WithMessage("La fecha de cancelación es obligatoria.");
    }
}


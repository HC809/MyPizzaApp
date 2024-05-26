using FluentValidation;

namespace AlbaPizzaApp.Application.Orders.ConfirmOrder;
internal sealed class ConfirmOrderCommandValidator : AbstractValidator<ConfirmOrderCommand>
{
    public ConfirmOrderCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("El ID del pedido es obligatorio.");

        RuleFor(x => x.ConfirmDate)
            .NotEmpty().WithMessage("La fecha de confirmación es obligatoria.");
    }
}


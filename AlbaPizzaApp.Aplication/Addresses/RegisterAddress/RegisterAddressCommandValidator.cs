using FluentValidation;

namespace AlbaPizzaApp.Application.Addresses.RegisterAddress;
internal sealed class RegisterAddressCommandValidator : AbstractValidator<RegisterAddressCommand>
{
    public RegisterAddressCommandValidator()
    {
        RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("El ID del cliente es obligatorio.");

        RuleFor(x => x.Country)
                .NotEmpty().WithMessage("El país es obligatorio.")
                .MaximumLength(50).WithMessage("El país debe tener como máximo 50 caracteres.");

        RuleFor(x => x.State)
                .NotEmpty().WithMessage("El estado es obligatorio.")
                .MaximumLength(50).WithMessage("El estado debe tener como máximo 50 caracteres.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("La ciudad es obligatoria.")
            .MaximumLength(100).WithMessage("La ciudad debe tener como máximo 100 caracteres.");

        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("La calle es obligatoria.")
            .MaximumLength(200).WithMessage("La calle debe tener como máximo 200 caracteres.");

        RuleFor(x => x.ZipCode)
            .NotEmpty().WithMessage("El código postal es obligatorio.")
            .MaximumLength(20).WithMessage("El código postal debe tener como máximo 20 caracteres.");
    }
}


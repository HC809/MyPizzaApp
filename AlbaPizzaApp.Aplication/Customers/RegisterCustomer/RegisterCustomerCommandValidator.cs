using FluentValidation;

namespace AlbaPizzaApp.Application.Customers.RegisterCustomer;
internal sealed class RegisterCustomerCommandValidator : AbstractValidator<RegisterCustomerCommand>
{
    public RegisterCustomerCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre del cliente es requerido.")
            .MinimumLength(3).WithMessage("El nombre del cliente debe tener al menos 3 caracteres.")
            .MaximumLength(100).WithMessage("El nombre del cliente debe tener como máximo 100 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("El correo electrónico del cliente es requerido.")
            .EmailAddress().WithMessage("Se requiere una dirección de correo electrónico válida.")
            .MaximumLength(100).WithMessage("El correo electrónico del cliente debe tener como máximo 100 caracteres.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("El número de teléfono del cliente es requerido")
            .Matches(@"^\d{8}$").WithMessage("El número de teléfono del cliente debe tener exactamente 8 dígitos.");
    }
}


using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Customers.UpdateCustomer;
public sealed record UpdateCustomerCommand(
    Guid Id,
    string Name,
    string Email,
    string Phone) : ICommand;


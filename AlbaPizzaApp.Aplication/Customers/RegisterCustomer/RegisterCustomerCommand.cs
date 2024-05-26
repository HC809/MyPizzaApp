using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Customers.RegisterCustomer;
public sealed record RegisterCustomerCommand(
    string Name,
    string Email,
    string Phone) : ICommand<Guid>;


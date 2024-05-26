using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Customers.RemoveCustomer;
public sealed record RemoveCustomerCommand(Guid Id) : ICommand;


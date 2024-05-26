using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Orders.CancelOrder;
public sealed record CancelOrderCommand(Guid Id, DateTime CancelDate) : ICommand;


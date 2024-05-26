using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Orders.ConfirmOrder;
public sealed record ConfirmOrderCommand(Guid Id, DateTime ConfirmDate) : ICommand;


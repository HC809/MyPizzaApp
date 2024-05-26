using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.OrderDetails.RemoveOrderDetail;
public sealed record RemoveOrderDetailCommand(Guid Id, Guid OrderId) : ICommand;


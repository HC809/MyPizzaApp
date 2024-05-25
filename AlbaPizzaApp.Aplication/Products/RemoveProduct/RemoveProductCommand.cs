using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Products.RemoveProduct;
public sealed record RemoveProductCommand(Guid Id) : ICommand;

using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Products.RegisterProduct;
public sealed record RegisterProductCommand(
    string Description,
    decimal Price,
    string TaxType) : ICommand<Guid>;

using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Products.UpdateProduct;
public sealed record UpdateProductCommand(
    Guid Id,
    string Description,
    decimal Price,
    string TaxType) : ICommand;

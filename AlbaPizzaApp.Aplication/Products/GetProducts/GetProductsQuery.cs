using AlbaPizzaApp.Application.Abstractions.Messaging;

namespace AlbaPizzaApp.Application.Products.GetProducts;
public sealed record GetProductsQuery() : IQuery<IEnumerable<ProductResponse>>;

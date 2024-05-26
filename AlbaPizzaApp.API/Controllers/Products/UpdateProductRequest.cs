namespace AlbaPizzaApp.API.Controllers.Products;

public sealed record UpdateProductRequest(
    Guid Id,
    string Description,
    decimal Price,
    string TaxType);

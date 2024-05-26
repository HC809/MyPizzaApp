namespace AlbaPizzaApp.API.Controllers.Products;

public record RegisterProductRequest(
    string Description,
    decimal Price,
    string TaxType);

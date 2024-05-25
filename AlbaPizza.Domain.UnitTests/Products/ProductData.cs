using AlbaPizzaApp.Domain.Products;

namespace AlbaPizza.Domain.UnitTests.Products;
internal static class ProductData
{
    public static readonly string Description = "Pizza Suprema";
    public static readonly decimal Price= 350;
    public static readonly ProductTaxType TaxType = ProductTaxType.General;
}

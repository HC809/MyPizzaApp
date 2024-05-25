using AlbaPizza.Domain.Abstractions;
using AlbaPizzaApp.Domain.Products;

namespace AlbaPizza.Domain.Products;
public sealed class Product : Entity
{
    private Product(Guid id, string description, decimal price, ProductTaxType taxType) : base(id)
    {
        Description = description;
        Price = price;
        TaxType = taxType;
    }

    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public ProductTaxType TaxType { get; set; }

    public static Product Create(string description, decimal price, ProductTaxType taxType)
    {
        var product = new Product(new Guid(), description, price, taxType);

        return product;
    }

    public void Update(string description, decimal price, ProductTaxType taxType)
    {
        Description = description;
        Price = price;
        TaxType = taxType;
    }
}

using AlbaPizzaApp.Domain.Products;
using FluentAssertions;

namespace AlbaPizza.Domain.UnitTests.Products;
public class ProductTests 
{
    [Fact]
    public void Create_Should_SetPropertyValue()
    {
        // Act
        var product = Product.Create(ProductData.Description, ProductData.Price, ProductData.TaxType);

        // Assert
        product.Description.Should().Be(ProductData.Description);
        product.Price.Should().Be(ProductData.Price);
        product.TaxType.Should().Be(ProductData.TaxType);
    }
}

using AlbaPizzaApp.Domain.Customers;
using FluentAssertions;

namespace AlbaPizza.Domain.UnitTests.Customers;
public class CustomerTests
{
    [Fact]
    public void Create_Should_SetPropertyValue()
    {
        // Act
        var customer = Customer.Create(CustomerData.Name, CustomerData.Email, CustomerData.Phone);

        // Assert
        customer.Name.Should().Be(CustomerData.Name);
        customer.Email.Should().Be(CustomerData.Email);
        customer.Phone.Should().Be(CustomerData.Phone);
    }
}

using AlbaPizzaApp.Domain.OrderDetails;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AlbaPizzaApp.Domain.Products;
using AlbaPizzaApp.Domain.Orders;

namespace AlbaPizzaApp.Infraestructure.Configurations;

internal sealed class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.ToTable("OrderDetails");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.UnitPrice)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(x => x.PriceWithoutTax)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(x => x.TaxAmount)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(x => x.PriceWithTax)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(x => x.TaxType)
            .IsRequired()
            .HasConversion(
                taxType => taxType.ToString(),
                value => (ProductTaxType)Enum.Parse(typeof(ProductTaxType), value)
            );

        builder.Property(x => x.OrderId)
            .IsRequired();

        builder.Property(x => x.ProductId)
            .IsRequired();

        builder.HasOne<Order>()
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId);

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(od => od.ProductId);
    }
}

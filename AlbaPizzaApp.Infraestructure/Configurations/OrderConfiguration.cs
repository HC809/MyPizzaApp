using AlbaPizzaApp.Domain.Orders;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AlbaPizzaApp.Domain.Customers;
using AlbaPizzaApp.Domain.Addresses;

namespace AlbaPizzaApp.Infraestructure.Configurations;
internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.OrderDate)
            .IsRequired();

        builder.Property(x => x.Subtotal)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(x => x.TaxAmount)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(x => x.TotalAmount)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion(
                status => status.ToString(),
                value => (OrderStatus)Enum.Parse(typeof(OrderStatus), value)
            );

        builder.Property(x => x.ConfirmDate);

        builder.Property(x => x.CancelDate);

        builder.Property(x => x.CustomerId)
            .IsRequired();

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(x => x.AddressId)
            .IsRequired();

        builder.HasOne<Address>()
            .WithOne()
            .HasForeignKey<Order>(x => x.AddressId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}


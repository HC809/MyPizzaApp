using AlbaPizzaApp.Domain.Addresses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AlbaPizzaApp.Domain.Customers;

namespace AlbaPizzaApp.Infraestructure.Configurations;
internal sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Country)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.State)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.City)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Street)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(x => x.ZipCode)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.CustomerId).IsRequired();

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(x => x.CustomerId);
    }
}


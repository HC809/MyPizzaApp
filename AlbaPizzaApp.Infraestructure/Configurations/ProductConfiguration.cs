using AlbaPizzaApp.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlbaPizzaApp.Infraestructure.Configurations;
internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Price)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(x => x.TaxType)
            .IsRequired()
            .HasConversion(taxType => taxType.ToString(), value => (ProductTaxType)Enum.Parse(typeof(ProductTaxType), value));

        builder.HasIndex(x => x.Description).IsUnique();
    }
}

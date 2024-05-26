﻿using AlbaPizzaApp.Domain.Orders;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AlbaPizzaApp.Domain.Customers;

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

        builder.Property(x => x.CustomerId)
            .IsRequired();

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(x => x.CustomerId);
    }
}

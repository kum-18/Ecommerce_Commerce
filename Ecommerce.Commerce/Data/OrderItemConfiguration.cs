using Ecommerce.Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Commerce.Data;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("order_items");

        builder.HasKey(oi => oi.Guid);
        builder.Property(oi => oi.Guid)
            .HasColumnName("guid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(oi => oi.OrderId)
            .HasColumnName("order_id")
            .IsRequired();

        // Note: product_id is a soft link to your Catalog Microservice, so no .HasOne() relationship here!
        builder.Property(oi => oi.ProductId)
            .HasColumnName("product_id")
            .IsRequired();

        builder.Property(oi => oi.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

        builder.Property(oi => oi.UnitPrice)
            .HasColumnName("unit_price")
            .HasColumnType("decimal(10,3)")
            .IsRequired();

        builder.Property(oi => oi.ProductName)
            .HasColumnName("product_name")
            .HasMaxLength(100)
            .IsRequired();

        // Relationship: OrderItem -> Order
        builder.HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade); // If an order is deleted, wipe out its line items
    }
}
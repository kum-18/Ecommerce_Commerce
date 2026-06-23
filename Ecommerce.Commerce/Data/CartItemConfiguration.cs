using Ecommerce.Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Commerce.Data;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("cart_items");

        // Configures your Primary Key(cart_id, product_id) composite key
        builder.HasKey(ci => new { ci.CartId, ci.ProductId });

        builder.Property(ci => ci.CartId)
            .HasColumnName("cart_id");

        // Note: product_id is another soft link to your Catalog microservice
        builder.Property(ci => ci.ProductId)
            .HasColumnName("product_id");

        builder.Property(ci => ci.Quantity)
            .HasColumnName("quantity")
            .IsRequired();

        // Relationship: CartItem -> Cart
        builder.HasOne(ci => ci.Cart)
            .WithMany(c => c.CartItems)
            .HasForeignKey(ci => ci.CartId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
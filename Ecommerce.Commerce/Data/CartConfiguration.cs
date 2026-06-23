using Ecommerce.Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Commerce.Data;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("carts");

        builder.HasKey(c => c.Guid);
        builder.Property(c => c.Guid)
            .HasColumnName("guid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(c => c.CustomerId)
            .HasColumnName("customer_id")
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .HasColumnName("created_at")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(c => c.UpdatedAt)
            .HasColumnName("updated_at");
    }
}
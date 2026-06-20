using Ecommerce.Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Commerce.Data
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("orders");
            builder.HasKey(ord => ord.Id);

            builder.Property(ord => ord.Id)
            .HasColumnName("guid")
            .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(ord => ord.CustomerId)
            .HasColumnName("customer_id")
            .IsRequired();

            builder.Property(ord => ord.Status)
            .HasColumnName("status")
            .HasMaxLength(10)
            .IsRequired();

            builder.Property(ord => ord.Subtotal)
                .HasColumnName("subtotal")
                .HasColumnType("decimal(10,3)")
                .IsRequired();
            builder.Property(ord => ord.TaxAmount)
                .HasColumnName("tax_amount")
                .HasColumnType("decimal(10,3)")
                .IsRequired();
            builder.Property(ord => ord.ShippingAddress)
                .HasColumnName("shipping_addres")
                .HasColumnType("jsonb")
                .IsRequired();
            builder.Property(ord => ord.TotalAmount)
                .HasColumnName("total_amount")
                .HasColumnType("decimal(10,3)")
                .IsRequired();
            builder.Property(ord => ord.Notes)
               .HasColumnName("notes")
               .HasMaxLength(250)
               .IsRequired();

            builder.Property(ord => ord.PlacedAt)
               .HasColumnName("placed_at")
               .HasDefaultValueSql("current_timestamp")
               .IsRequired();

            builder.Property(ord => ord.UpdatedAt)
               .HasColumnName("updated_at");

            builder.HasOne(ord => ord.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey( ord => ord.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

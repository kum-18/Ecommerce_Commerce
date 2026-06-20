namespace Ecommerce.Commerce.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string? ShippingAddress { get; set; } // Maps to jsonb
        public string? Notes { get; set; }
        public DateTime PlacedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public Customer Customer { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}

using Ecommerce.Commerce.Models;

namespace Ecommerce.Commerce.DTOs
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public Address? ShippingAddress { get; set; }
        public string? Notes { get; set; }
        public DateTime PlacedAt { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
    }

    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
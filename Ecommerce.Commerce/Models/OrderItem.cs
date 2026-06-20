namespace Ecommerce.Commerce.Models
{
    public class OrderItem
    {
        public Guid Guid { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; } // Soft link to Catalog service
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductName { get; set; } = string.Empty;

        // Navigation properties
        public Order Order { get; set; } = null!;
    }
}

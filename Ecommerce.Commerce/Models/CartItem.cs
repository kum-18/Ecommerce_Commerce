namespace Ecommerce.Commerce.Models
{
    public class CartItem
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; } // Soft link to Catalog service
        public int Quantity { get; set; }

        // Navigation properties
        public Cart Cart { get; set; } = null!;
    }
}

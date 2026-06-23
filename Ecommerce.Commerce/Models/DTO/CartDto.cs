namespace Ecommerce.Commerce.Models.DTO
{
    public class CartDto
    {
        public Guid CartId { get; set; }
        public List<CartItemDto> Items { get; set; } = new();
        public Guid CustomerId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public decimal TotalCartAmount { get; set; }
    }

    public class CartItemDto : ProductDto
    {
        public int Quantity { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
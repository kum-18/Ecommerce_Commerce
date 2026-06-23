namespace Ecommerce.Commerce.Models.DTO
{
    public class ProductDto
    {
    
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
    }
}

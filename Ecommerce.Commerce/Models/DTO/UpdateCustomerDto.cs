namespace Ecommerce.Commerce.Models.DTO
{
    public class UpdateCustomerDto
    {
        public string? FirstName { get; set; } // Now optional!
        public string? LastName { get; set; }  // Now optional!
        public string? Email { get; set; }     // Now optional!
        public string? PhoneNumber { get; set; } // Now optional!
        public Address? Address { get; set; }
    }
}

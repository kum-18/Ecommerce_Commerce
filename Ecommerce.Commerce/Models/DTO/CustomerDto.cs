
using Ecommerce.Commerce.Models;
using Ecommerce.Commerce.Models.DTO;

namespace Ecommerce.Commerce.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Address? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TotalNoOrders { get; set; }
    }

    //public class CustomerDetailedDto
    //{
    //    public Guid Id { get; set; }
    //    public string FirstName { get; set; } = string.Empty;
    //    public string LastName { get; set; } = string.Empty;
    //    public string Email { get; set; } = string.Empty;
    //    public CartDto? ActiveCart { get; set; }
    //}
}
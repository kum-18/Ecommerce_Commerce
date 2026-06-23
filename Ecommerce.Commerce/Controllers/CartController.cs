using Ecommerce.Commerce.Data;
using Ecommerce.Commerce.Models;
using Ecommerce.Commerce.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ApplicationDbContext dbContext;
        public CartController (ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        [HttpGet("/{userId}")]
        public async Task <ActionResult<CartDto>> GetCartItems(string userId)
        {
            bool isValidUser = Guid.TryParse(userId, out Guid ValidUserId);
            if(!isValidUser)
            {
                return BadRequest("Invalid UserId");
            }

            var CartDetails = await dbContext.Carts.Where((cart) => cart.CustomerId == ValidUserId).Select((cart) => new CartDto
            {
                CartId = cart.Guid,
                UpdatedAt = cart.UpdatedAt ?? DateTime.MaxValue,
                CustomerId = ValidUserId,
                Items = cart.CartItems.Select((item) => new CartItemDto
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                }).ToList()
            }).FirstOrDefaultAsync();

            var uniqueProductIds = CartDetails.Items.Select(item => item.ProductId).Distinct();

        }
    }
}

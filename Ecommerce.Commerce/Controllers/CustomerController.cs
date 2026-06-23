using Ecommerce.Commerce.Data;
using Ecommerce.Commerce.DTOs;
using Ecommerce.Commerce.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private ApplicationDbContext _dbContext;
        public CustomerController ( ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet("/{userId}")]
        public async Task <ActionResult<CustomerDto>> GetCustomerDetails(string userId)
        {
            if(userId == null)
            {
                return BadRequest("UserId is required");

            }
            var isValidUserId = Guid.TryParse(userId, out Guid ValidUserId);
            if(!isValidUserId)
            {
                return BadRequest("Invalid User Id");
            }
            var UserDetails = await _dbContext.Customers.Where((customer) => customer.Id == ValidUserId).Select((c) => new CustomerDto {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address,
                CreatedAt = c.CreatedAt,
                TotalNoOrders = c.Orders.Count

            }
            ).FirstOrDefaultAsync();

            if (UserDetails == null)
            {
                return NotFound("Customer not found"); // Good practice to check if they exist!
            }

            return Ok(UserDetails);
        }

        [HttpPut("{userId}")] // Best practice: Use HttpPut for updates, and omit the leading slash
        public async Task<IActionResult> UpdateCustomerDetails(string userId, [FromBody] UpdateCustomerDto updateDto)
        {
            // 1. Validate Input Params
            if (string.IsNullOrWhiteSpace(userId))
            {
                return BadRequest("UserId is required.");
            }

            if (updateDto == null)
            {
                return BadRequest("Update payload cannot be empty.");
            }

            var isValidUserId = Guid.TryParse(userId, out Guid validUserId);
            if (!isValidUserId)
            {
                return BadRequest("Invalid User Id format.");
            }

            // 2. Fetch the existing tracking tracked entity directly from DB
            var customer = await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.Id == validUserId);

            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            // Only overwrite the database if the frontend actually sent a new value!
            if (!string.IsNullOrWhiteSpace(updateDto.FirstName))
            {
                customer.FirstName = updateDto.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(updateDto.LastName))
            {
                customer.LastName = updateDto.LastName;
            }

            if (!string.IsNullOrWhiteSpace(updateDto.Email))
            {
                customer.Email = updateDto.Email;
            }

            if (!string.IsNullOrWhiteSpace(updateDto.PhoneNumber))
            {
                customer.PhoneNumber = updateDto.PhoneNumber;
            }

            // For objects like Address, check for null before updating
            if (updateDto.Address != null)
            {
                customer.Address = updateDto.Address;
            }

            // 4. Save changes back to Postgres
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // Catches database constraint violations (e.g. trying to change email to one that already exists)
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating user details. The Email or Phone Number may already be in use.");
            }

            // 5. Return 204 No Content (standard for successful PUT requests)
            return Ok("User Updated sucessfully");
        }

    }


}

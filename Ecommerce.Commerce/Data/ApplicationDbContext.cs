using Microsoft.EntityFrameworkCore;
using Ecommerce.Commerce.Models;
namespace Ecommerce.Commerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base() { }
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<Order> OrderItems => Set<Order>();
        public DbSet<Order> CartItems => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Picks up every IEntityTypeConfiguration class in this assembly
            // automatically — you never need to call modelBuilder.ApplyConfiguration()
            // manually for each one
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly
            );
        }
    }
}

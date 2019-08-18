using Microsoft.EntityFrameworkCore;

namespace Materializer
{
    public class OrderReadDbContext : DbContext
    {
        public OrderReadDbContext(DbContextOptions<OrderReadDbContext> options) : base(options)
        {

        }

        public DbSet<OrderPreview> OrderPreviews { get; set; }
    }

    public class OrderWriteDbContext : DbContext
    {
        public OrderWriteDbContext(DbContextOptions<OrderWriteDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

    }

    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}

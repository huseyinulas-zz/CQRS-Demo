using Microsoft.EntityFrameworkCore;
using LNLOrder.Write.Application.Abstraction;
using LNLOrder.Domain.Entities;

namespace LNLOrder.Write.Persistance
{
    public class OrderReadDbContext : DbContext, IOrderReadDbContext
    {
        public OrderReadDbContext(DbContextOptions<OrderReadDbContext> options) : base(options)
        {

        }

        public DbSet<OrderPreview> OrderPreviews { get; set; }
    }
}

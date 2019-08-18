using Microsoft.EntityFrameworkCore;
using LNLOrder.Write.Application.Abstraction;
using LNLOrder.Write.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LNLOrder.Persistance.Configurations;

namespace LNLOrder.Write.Persistance
{
    public class OrderWriteDbContext : DbContext, IOrderWriteDbContext
    {
        public OrderWriteDbContext(DbContextOptions<OrderWriteDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguration());
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}

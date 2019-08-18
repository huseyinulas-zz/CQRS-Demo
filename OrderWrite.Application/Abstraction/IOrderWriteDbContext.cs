using Microsoft.EntityFrameworkCore;
using LNLOrder.Write.Domain.Entities;
using System.Threading.Tasks;

namespace LNLOrder.Write.Application.Abstraction
{
    public interface IOrderWriteDbContext
    {
        DbSet<Customer> Customers { get; set; }

        DbSet<Product> Products { get; }

        DbSet<Order> Orders { get; }


        Task<int> SaveChangesAsync();
    }
    
}

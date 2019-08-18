using LNLOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LNLOrder.Write.Application.Abstraction
{
    public interface IOrderReadDbContext
    {
        DbSet<OrderPreview> OrderPreviews { get; set; }
    }   
}

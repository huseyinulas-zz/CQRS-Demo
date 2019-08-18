using LNLOrder.Write.Application.Abstraction;
using LNLOrder.Write.Application.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNLOrder.Application.Orders.Queries
{
    public class OrderPreviewQueryHandler : IQueryHandler<OrderPreviewQuery, List<OrderPreviewDto>>
    {
        private readonly IOrderReadDbContext _orderReadDbContext;

        public OrderPreviewQueryHandler(IOrderReadDbContext orderReadDbContext)
        {
            _orderReadDbContext = orderReadDbContext;
        }

        public async Task<List<OrderPreviewDto>> Handle(OrderPreviewQuery query)
        {
            var orderPreviews = await _orderReadDbContext.OrderPreviews.Select(i => new OrderPreviewDto {
                CustomerAddress = i.CustomerAddress,
                CustomerName = i.CustomerName,
                OrderId = i.OrderId,
                ProductName = i.ProductName,
                Quantity = i.Quantity,
                Total = i.Total
            })
            .ToListAsync();

            return orderPreviews;
        }
    }
}

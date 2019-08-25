using LNLOrder.Application.Orders.Events;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Materializer
{
    public class OrderMaterializerConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly OrderReadDbContext _orderReadDbContext;
        private readonly OrderWriteDbContext _orderWriteDbContext;
        public OrderMaterializerConsumer(OrderReadDbContext orderReadDbContext, OrderWriteDbContext orderWriteDbContext)
        {
            _orderReadDbContext = orderReadDbContext;
            _orderWriteDbContext = orderWriteDbContext;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var eventMessage = context.Message;

            var customer = await _orderWriteDbContext.Customers.FirstOrDefaultAsync(i => i.CustomerId == eventMessage.CustomerId);

            var product = await _orderWriteDbContext.Products.FirstOrDefaultAsync(i => i.ProductId == eventMessage.ProductId);

            _orderReadDbContext.OrderPreviews.Add(new OrderPreview
            {
                OrderStatus = eventMessage.OrderStatus,
                CustomerAddress = customer.Adress,
                CustomerId = customer.CustomerId,
                CustomerName = customer.Name,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                OrderId = eventMessage.OrderId,
                Quantity = eventMessage.Quantity,
                Total = eventMessage.Total
            });

            await _orderReadDbContext.SaveChangesAsync();

            await Console.Out.WriteLineAsync($"OrderId={eventMessage.OrderId} has processed!");
        }
    }
}

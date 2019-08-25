using LNLOrder.Application.Orders.Events;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Materializer
{
    public class OrderCanceledConsumer : IConsumer<OrderCanceledEvent>
    {
        private readonly OrderReadDbContext _orderReadDbContext;

        public OrderCanceledConsumer(OrderReadDbContext orderReadDbContext)
        {
            _orderReadDbContext = orderReadDbContext;
        }

        public async Task Consume(ConsumeContext<OrderCanceledEvent> context)
        {
            var order = await _orderReadDbContext.OrderPreviews.FirstOrDefaultAsync(i => i.OrderId == context.Message.OrderID);

            order.OrderStatus = "Canceled";

            await _orderReadDbContext.SaveChangesAsync();

            await Console.Out.WriteLineAsync($"OrderId={context.Message.OrderID} has processed!");
        }
    }
}

using LNLOrder.Application.Abstraction;
using LNLOrder.Application.Orders.Events;
using LNLOrder.Write.Application.Abstraction;
using LNLOrder.Write.Application.Infrastructure;
using LNLOrder.Write.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LNLOrder.Write.Application.Orders.Commands
{
    public class OrderCommandHandler : ICommandHandler<CreateOrderCommand>, ICommandHandler<CancelOrderCommand>
    {
        private readonly IOrderWriteDbContext _dbContext;
        private readonly INotificationService _notificationService;

        public OrderCommandHandler(IOrderWriteDbContext dbContext, INotificationService notificationService)
        {
            _dbContext = dbContext;
            _notificationService= notificationService;
        }

        public async Task Handle(CreateOrderCommand command)
        {
            //TODO: validations

            var product = await _dbContext.Products.FirstOrDefaultAsync(i => i.ProductId == command.ProductId);

            var order = new Order
            {
                CustomerId = command.CustomerId,
                ProductId = command.ProductId,
                Quantity = command.Quantity,
                Total = product.Price * command.Quantity,
                OrderStatus = "Approved"
            };

            _dbContext.Orders.Add(order);

            await _dbContext.SaveChangesAsync();

            await _notificationService.Notify(new OrderCreatedEvent(order.OrderId, order.ProductId, order.CustomerId, order.Quantity, order.Total, order.OrderStatus));
        }

        public async Task Handle(CancelOrderCommand command)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(i => i.OrderId == command.OrderId);

            order.OrderStatus = "Canceled";

            await _dbContext.SaveChangesAsync();

            await _notificationService.Notify(new OrderCanceledEvent(command.OrderId));
        }
    }
}

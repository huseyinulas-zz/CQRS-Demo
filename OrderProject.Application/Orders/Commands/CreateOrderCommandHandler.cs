using LNLOrder.Application.Abstraction;
using LNLOrder.Application.Orders.Events;
using LNLOrder.Write.Application.Abstraction;
using LNLOrder.Write.Application.Infrastructure;
using LNLOrder.Write.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LNLOrder.Write.Application.Orders.Commands
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IOrderWriteDbContext _dbContext;
        private readonly INotificationService _notificationService;

        public CreateOrderCommandHandler(IOrderWriteDbContext dbContext, INotificationService notificationService)
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
                Total = product.Price * command.Quantity
            };

            _dbContext.Orders.Add(order);

            await _dbContext.SaveChangesAsync();

            await _notificationService.Notify(new OrderCreatedEvent(order.OrderId, order.ProductId, order.CustomerId, order.Quantity, order.Total));
        }
    }
}

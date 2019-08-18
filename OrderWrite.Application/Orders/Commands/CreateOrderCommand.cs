using LNLOrder.Write.Application.Infrastructure;

namespace LNLOrder.Write.Application.Orders.Commands
{
    public class CreateOrderCommand : ICommand
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}

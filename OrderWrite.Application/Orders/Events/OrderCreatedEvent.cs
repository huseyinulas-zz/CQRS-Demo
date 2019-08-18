using LNLOrder.Application.Abstraction;

namespace LNLOrder.Application.Orders.Events
{
    public class OrderCreatedEvent : IEvent
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public OrderCreatedEvent(int orderId, int productId, int customerId, int quantity, decimal total)
        {
            OrderId = orderId;
            ProductId = productId;
            CustomerId = customerId;
            Quantity = quantity;
            Total = total;
        }
    }
}

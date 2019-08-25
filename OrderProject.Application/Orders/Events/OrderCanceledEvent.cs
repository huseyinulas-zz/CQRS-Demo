using LNLOrder.Application.Abstraction;

namespace LNLOrder.Application.Orders.Events
{
    public class OrderCanceledEvent : IEvent
    {
        public int OrderID { get; set; }

        public OrderCanceledEvent(int orderId)
        {
            OrderID = orderId;
        }
    }
}

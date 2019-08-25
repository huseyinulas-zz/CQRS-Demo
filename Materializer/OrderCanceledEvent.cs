namespace LNLOrder.Application.Orders.Events
{
    public class OrderCanceledEvent
    {
        public int OrderID { get; set; }

        public OrderCanceledEvent(int orderId)
        {
            OrderID = orderId;
        }
    }
}

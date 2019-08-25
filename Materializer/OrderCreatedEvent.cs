namespace LNLOrder.Application.Orders.Events
{
    public class OrderCreatedEvent
    {
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}

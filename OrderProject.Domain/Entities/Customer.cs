using LNLOrder.Domain.ValueObjects;

namespace LNLOrder.Write.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public Email Email { get; set; }
    }
}

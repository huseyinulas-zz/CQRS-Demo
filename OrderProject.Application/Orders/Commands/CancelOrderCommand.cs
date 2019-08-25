using System;
using LNLOrder.Write.Application.Infrastructure;
using Newtonsoft.Json;

namespace LNLOrder.Write.Application.Orders.Commands
{
    public class CancelOrderCommand : ICommand
    {
        [JsonIgnore]
        public string Id { get; set; }

        public int OrderId { get; set; }

        public CancelOrderCommand()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

using System;
using LNLOrder.Domain.Infrastructure;

namespace LNLOrder.Write.Domain.Entities
{
    public class Event 
    {
        public string AggregateId { get; set; }
        public string AggregateType { get; set; }
        public int Version { get; set; }
        public string Payload { get; set; }
        public string Id { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}

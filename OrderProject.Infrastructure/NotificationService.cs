using MassTransit;
using LNLOrder.Application.Abstraction;
using System.Threading.Tasks;
using System;

namespace LNLOrder.Infrastructure
{
    public class NotificationService : INotificationService
    {
        private readonly IBus _bus;

        public NotificationService(IBus bus)
        {
            _bus = bus;
        }


        public async Task Notify(object @event)
        {
            await _bus.Publish(@event);
        }
      
    }
}

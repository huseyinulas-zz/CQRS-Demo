using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LNLOrder.Application.Abstraction
{
    public interface INotificationService
    {
        Task Notify(object @event);
    }
}

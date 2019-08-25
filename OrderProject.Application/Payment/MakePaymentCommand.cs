using LNLOrder.Write.Application.Infrastructure;
using System;

namespace LNLOrder.Application.Payment
{
    public class MakePaymentCommand: ICommand
    {
        public string OrderId { get; set; }
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }

        public string Id { get; set; }

        public MakePaymentCommand()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}

//using LNLOrder.Write.Application.Abstraction;
//using LNLOrder.Write.Application.Infrastructure;
//using LNLOrder.Write.Domain.Entities;
//using Newtonsoft.Json;
//using System;
//using System.Threading.Tasks;

//namespace LNLOrder.Application.Payment
//{
//    public class MakePaymentCommandHandler : ICommandHandler<MakePaymentCommand>
//    {
//        private readonly IOrderWriteDbContext _orderWriteDbContext;

//        public MakePaymentCommandHandler(IOrderWriteDbContext orderWriteDbContext)
//        {
//            _orderWriteDbContext = orderWriteDbContext;
//        }

//        public async Task Handle(MakePaymentCommand command)
//        {
            
//            _orderWriteDbContext.Events.Add(new Event
//            {
//                AggregateId = command.OrderId,
//                AggregateType = nameof(MakePaymentCommand),
//                EventId = Guid.NewGuid().ToString(),
//                Payload = JsonConvert.SerializeObject(command),
//                Version = 1
//            });

//            await _orderWriteDbContext.SaveChangesAsync();
//        }
//    }
//}

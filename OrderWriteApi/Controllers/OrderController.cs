using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LNLOrder.Write.Application.Infrastructure;
using LNLOrder.Write.Application.Orders.Commands;

namespace LNLOrder.Write.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICommandHandler<CreateOrderCommand> _creteOrderCommand;
        private readonly ICommandHandler<CancelOrderCommand> _cancelOrderCommand;

        public OrderController(ICommandHandler<CreateOrderCommand> creteOrderCommand, ICommandHandler<CancelOrderCommand> cancelOrderCommand)
        {
            _creteOrderCommand = creteOrderCommand;
            _cancelOrderCommand = cancelOrderCommand;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            await _creteOrderCommand.Handle(command);

            return Ok();

        }


        [HttpPost]
        [Route("Cancel")]
        public async Task<IActionResult> CancelOrder(CancelOrderCommand command)
        {
            await _cancelOrderCommand.Handle(command);

            return Ok();

        }
    }
}
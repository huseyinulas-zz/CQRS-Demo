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
        private readonly ICommandHandler<CreateOrderCommand> _commandHandler;

        public OrderController(ICommandHandler<CreateOrderCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            await _commandHandler.Handle(command);

            return Ok();

        }
    }
}
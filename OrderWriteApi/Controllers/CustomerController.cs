using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LNLOrder.Write.Application.Customers;
using LNLOrder.Write.Application.Infrastructure;

namespace LNLOrder.Write.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICommandHandler<RegisterCustomerCommand> _commandHandler;

        public CustomerController(ICommandHandler<RegisterCustomerCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomerCommand command)
        {
            await _commandHandler.Handle(command);

            return Ok();

        }
    }
}
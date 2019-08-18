using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LNLOrder.Write.Application.Infrastructure;
using LNLOrder.Write.Application.Products;

namespace LNLOrder.Write.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICommandHandler<CreateProductCommand> _commandHandler;

        public ProductController(ICommandHandler<CreateProductCommand> commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _commandHandler.Handle(command);

            return Ok();

        }
    }
}
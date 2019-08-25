using System.Collections.Generic;
using System.Threading.Tasks;
using LNLOrder.Application.Orders.Queries;
using LNLOrder.Domain.Entities;
using LNLOrder.Write.Application.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace LNLOrder.ReadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderPreviewController : ControllerBase
    {
        private readonly IQueryHandler<OrderPreviewQuery, List<OrderPreviewDto>> _queryHandler;

        public OrderPreviewController(IQueryHandler<OrderPreviewQuery, List<OrderPreviewDto>> queryHandler)
        {
            _queryHandler = queryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderPreview()
        {
            List<OrderPreviewDto> orderList = await _queryHandler.Handle(new OrderPreviewQuery());

            return Ok(orderList);
        }
    }
}

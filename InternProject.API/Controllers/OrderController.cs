using InternProject.Application.Features.Orders.Commands;
using InternProject.Application.Features.Orders.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InternProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderHandler command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteOrder(int Id)
        {

            var result = await _mediator.Send(new DeleteOrder(Id));
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllOrders()
        {
            var result = await _mediator.Send(new GetOrders());
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderHandler command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var result = await _mediator.Send(new GetOrderById(id));
            return Ok(result);
        }
    }

}

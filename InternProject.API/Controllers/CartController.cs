using InternProject.Application.Features.Cart.Commands;
using InternProject.Application.Features.Cart.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace InternProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles ="Customer")]
        public async Task<IActionResult> AddToCart( [FromBody] AddToCartDto request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _mediator.Send(new AddToCart(userId, request));
            return Ok(new
            {
                message = result
            });
        }
    }
}

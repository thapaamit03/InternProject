using InternProject.Application.Features.Products.DTOs;
using InternProject.Application.Features.Products.Queries;
using InterProject.Application.Features.Products.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto request)
        {
            var result = await _mediator.Send(new CreateProduct(request));

            return Ok(new
            {
                productId=result.Id,
                ProductName = result.Name,
                price = result.Price,
                category=result.Category
            });
        }

        [HttpGet]
        [Authorize(Roles ="Admin,Customer")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _mediator.Send(new GetProducts());

            return Ok(result);
        }
        
    }
}

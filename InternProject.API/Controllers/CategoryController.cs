using InternProject.Application.Features.Categories.Commands;
using InternProject.Application.Features.Categories.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto request)
        {
            var result = await _mediator.Send(new CreateCategory(request));

            return Ok(
                new
                {
                    message="category created successfully",
                    CategoryName = result.Name,
                    CategoryId = result.Id
                });
        }
    }
}

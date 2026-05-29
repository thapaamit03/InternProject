using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Categories.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Features.Categories.Commands
{
    public record CreateCategory(CreateCategoryDto dto):IRequest<CategoryResponseDto>
    {
    }
    public class CreateCategoryHandler:IRequestHandler<CreateCategory,CategoryResponseDto>
    {
        private ICategoryRepo _repo;
        public CreateCategoryHandler(ICategoryRepo repo)
        {
            _repo = repo;
        }
        public async Task<CategoryResponseDto> Handle(CreateCategory request, CancellationToken cancellationToken)
        {
           return await _repo.CreateAsync(request.dto);
        }
    }
}

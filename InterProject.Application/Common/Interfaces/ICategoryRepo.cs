using InternProject.Application.Features.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Common.Interfaces
{
    public interface ICategoryRepo
    {
        Task<CategoryResponseDto> CreateAsync(CreateCategoryDto dto);
        Task<List<CategoryResponseDto>> GetAllAsync();
    }
}

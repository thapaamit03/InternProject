using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Categories.DTOs;
using InternProject.Domain.Models;
using InternProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InternProject.Infrastructure.Repositories
{
    public class CategoryRepo:ICategoryRepo
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepo(ApplicationDbContext context)
        {
            _context = context;
        }

       public async  Task<CategoryResponseDto> CreateAsync(CreateCategoryDto dto)
        {

            var category = new Category
            {
                Name = dto.Name
            };

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return new CategoryResponseDto
            {
                Name = category.Name,
                Id = category.Id
            };
        }

        public async Task<List<CategoryResponseDto>> GetAllAsync()
        {
          return  await _context.Categories
                .Select(c => new CategoryResponseDto
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }
    }
}

using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Categories.DTOs;
using InternProject.Application.Features.Products.DTOs;
using InternProject.Domain.Models;
using InternProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InternProject.Infrastructure.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductResponseDto> CreateProductAsync(CreateProductDto request)
        {
            var categoryExists = await _context.Categories.FirstOrDefaultAsync(c => c.Id == request.CategoryId);
            if (categoryExists is null)
            {
                throw new Exception("category with given id is not found");
            }
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
                CategoryId=request.CategoryId,
                CreatedAt = DateTime.UtcNow
            };

            await _context.AddAsync(product);
             await _context.SaveChangesAsync();
            
            

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category= new CategoryResponseDto
                {
                    Id=product.Category.Id,
                    Name=product.Category.Name
                }
            };
        }

         public async Task<List<ProductResponseDto>> GetProductsAsync()
        {
            var products=await _context.Products
                .Include(p => p.Category)
                .ToListAsync();

            return products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = new CategoryResponseDto
                {
                    Id = p.Category.Id,
                    Name = p.Category.Name
                }
            }).ToList();
        }
    }
    }

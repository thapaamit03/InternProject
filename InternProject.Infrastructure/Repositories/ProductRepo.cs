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

       public async Task<ProductResponseDto> DeleteProductAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if(product is null)
            {
                throw new Exception("Product with given id is not found");
            }
            var response = new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = new CategoryResponseDto
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                }
            };

            _context.Products.Remove(product);
            _context.SaveChanges();

            return response;
        }

        public async Task<ProductResponseDto> UpdateProductAsync(int id, CreateProductDto request)
        {
            var product =await _context.Products
                .Include(p=> p.Category)
                .FirstOrDefaultAsync(p=>p.Id == id);

            if( product is null)
            {
                throw new Exception("Product with given id is not found");
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.Stock = request.Stock;
            product.CategoryId = request.CategoryId;
            product.UpdatedAt = DateTime.UtcNow;
          
            await _context.SaveChangesAsync();

            var response = new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = new CategoryResponseDto
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                }
            };

            return response;
        }
    }
 }

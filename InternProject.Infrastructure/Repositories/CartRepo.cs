using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Cart.DTOs;
using InternProject.Domain.Models;
using InternProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InternProject.Infrastructure.Repositories
{
    public class CartRepo:ICartRepo
    {
        private readonly ApplicationDbContext _context;
        public CartRepo(ApplicationDbContext context)
        {
            _context = context;
        }

          public async  Task<string> AddToCart(string userId, AddToCartDto dto)
            {
                var existingCart = await _context.Carts
                                            .Include(c=>c.CartItems)
                                            .FirstOrDefaultAsync(c=>c.UserId==userId);
                if(existingCart is null)
                {
                    existingCart = new Cart
                    {
                        UserId = userId,
                        CartItems = new List<CartItem>()
                    };

                    await _context.Carts.AddAsync(existingCart);
                }

                var existingCartItem = existingCart.CartItems.FirstOrDefault(ci => ci.ProductId == dto.ProductId);

                if(existingCartItem is not null)
                {
                    existingCartItem.Quantity += dto.Quantity;
                }
                else
                {
                    existingCart.CartItems.Add(new CartItem
                    {
                        ProductId = dto.ProductId,
                        Quantity = dto.Quantity
                    });
                }

                await _context.SaveChangesAsync();
                return "Item added to cart ";
            }

        public async Task<CartResponseDto> GetCartItems(string userId)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if(cart is null)
            {
                return null;
            }

            return new CartResponseDto
            {
                CartId = cart.Id,
                Items = cart.CartItems.Select(ci => new CartItemResponseDto
                {
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Price = ci.Product.Price,
                    Quantity = ci.Quantity
                }).ToList()
            };
        }
    }
}

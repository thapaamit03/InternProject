using InternProject.Application.Features.Cart.DTOs;
using InternProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Common.Interfaces
{
    public interface ICartRepo
    {
        Task<string> AddToCart(string userId, AddToCartDto dto);

           Task<CartResponseDto> GetCartItems(string userId);

        Task<string> RemoveFromCart(string userId, int cartItemId, int quantity);

        //Task RemoveCartItem(int cartItemId);
    }
}

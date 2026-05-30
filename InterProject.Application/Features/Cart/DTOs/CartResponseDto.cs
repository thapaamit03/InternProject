using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Features.Cart.DTOs
{
    public class CartResponseDto
    {
        public int CartId { get; set; }

        public List<CartItemResponseDto> Items { get; set; }

        public decimal GrandTotal =>
            Items.Sum(i => i.TotalPrice);
    }
}

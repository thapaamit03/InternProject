using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Features.Cart.DTOs
{
    public class AddToCartDto
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Features.Orders.DTOs
{
    public class OrderResponseDto
    {
       public int Id { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal DiscountAmount { get; set; }
    }
}

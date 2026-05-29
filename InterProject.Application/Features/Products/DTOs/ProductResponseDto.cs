using InternProject.Application.Features.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Features.Products.DTOs
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public CategoryResponseDto? Category { get; set; }
    }
}

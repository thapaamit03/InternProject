using InternProject.Application.Features.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Common.Interfaces
{
    public interface IProductRepo
    {
        Task<ProductResponseDto> CreateProductAsync(CreateProductDto request);

        Task< List< ProductResponseDto>> GetProductsAsync();
    }
}

using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Products.DTOs;
using InterProject.Application.Features.Products.DTOs;
using MediatR;

namespace InterProject.Application.Features.Products.Commands
{
    public record UpdateProduct(int Id, CreateProductDto Product) : IRequest<ProductResponseDto>;

    public class UpdateProductHandler(IProductRepo productRepo) : IRequestHandler<UpdateProduct, ProductResponseDto>
    {
        public async Task<ProductResponseDto> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
           return await productRepo.UpdateProductAsync(request.Id, request.Product);

            
        }
    }
    
}

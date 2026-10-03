using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Products.DTOs;
using MediatR;

namespace InterProject.Application.Features.Products.Commands
{
    public record DeleteProduct(int Id) : IRequest<ProductResponseDto>;
    
    public class DeleteProductHandler(IProductRepo productRepo):IRequestHandler<DeleteProduct, ProductResponseDto>
    {
        public async Task<ProductResponseDto> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            
            return await productRepo.DeleteProductAsync(request.Id);

        }
    }
}

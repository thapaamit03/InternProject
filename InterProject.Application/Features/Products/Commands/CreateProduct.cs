using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Products.DTOs;
using MediatR;

namespace InterProject.Application.Features.Products.Commands
{
    public record CreateProduct(CreateProductDto requestDto) : IRequest<ProductResponseDto>;

    public class CreateProductHandler : IRequestHandler<CreateProduct, ProductResponseDto>
    {
        private readonly IProductRepo _repo;
        public CreateProductHandler(IProductRepo repo)
        {
            _repo = repo;
        }
        public async Task<ProductResponseDto> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
          return  await _repo.CreateProductAsync(request.requestDto);
        }
    }
}

using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Products.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Features.Products.Queries
{
    public record GetProducts:IRequest<List<ProductResponseDto>>
    {
    }
    public class GetProductsHandler:IRequestHandler<GetProducts,List<ProductResponseDto>>
    {
        private readonly IProductRepo _repo;
        public GetProductsHandler(IProductRepo repo)
        {
            _repo = repo;
        }
        public async Task<List<ProductResponseDto>> Handle(GetProducts request, CancellationToken cancellationToken)
        {
          return  await _repo.GetProductsAsync();
        }
    }
}

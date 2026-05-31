using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Cart.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Features.Cart.Queries
{
    public record GetCartItems(string userId):IRequest<CartResponseDto>
    {
    }

    public class GetCartHandler:IRequestHandler<GetCartItems,CartResponseDto>
    {
        private readonly ICartRepo _repo;
        public GetCartHandler(ICartRepo repo)
        {
            _repo = repo;
        }
        public async  Task<CartResponseDto> Handle(GetCartItems request, CancellationToken cancellationToken)
        {
          return  await _repo.GetCartItems(request.userId);
        }
    }
}

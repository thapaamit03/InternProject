using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Cart.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Features.Cart.Commands
{
    public record AddToCart(string userId,AddToCartDto dto):IRequest<string>
    {
    }

    public class AddCartHandler:IRequestHandler<AddToCart,string>
    {
        private readonly ICartRepo _repo;
        public AddCartHandler(ICartRepo repo)
        {
            _repo = repo;
        }
        public async Task<string> Handle(AddToCart request, CancellationToken cancellationToken)
        {

         return  await _repo.AddToCart(request.userId,request.dto);

        }
    }
}


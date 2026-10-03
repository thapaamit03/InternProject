using InternProject.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Features.Cart.Commands
{
    public record RemoveFromCart(int cartItemId, int quantity,string UserId) : IRequest<string>;
    
    public class RemoveFromCartHandler(ICartRepo cartRepo) : IRequestHandler<RemoveFromCart, string>
    {
        public async Task<string> Handle(RemoveFromCart request, CancellationToken cancellationToken)
        {
          return  await cartRepo.RemoveFromCart(request.UserId,request.cartItemId, request.quantity);

        }
    }

}

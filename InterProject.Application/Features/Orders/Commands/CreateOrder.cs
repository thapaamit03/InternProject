using InternProject.Application.Common.Interfaces;
using InternProject.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Features.Orders.Commands
{
    public record CreateOrder(Order Order) : IRequest<int>;

    public class CreateOrderHandler(IOrderRepo order) : IRequestHandler<CreateOrder, int>
    {
        public async Task<int> Handle(CreateOrder request, CancellationToken cancellationToken)
        {
            return await order.CreateOrderAsync(request.Order, cancellationToken);
        }
    };
    

}

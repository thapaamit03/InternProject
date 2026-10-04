using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Orders.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Features.Orders.Queries
{
    public record GetOrders() : IRequest<List<OrderResponseDto>>;
    
    public class GetOrdersHandler(IOrderRepo order) : IRequestHandler<GetOrders, List<OrderResponseDto>>
    {
        public async Task<List<OrderResponseDto>> Handle(GetOrders request, CancellationToken cancellationToken)
        {
            return await order.GetAllOrdersAsync(cancellationToken);
        }
    }
}

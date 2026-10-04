using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Orders.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Features.Orders.Queries
{
    public record GetOrderById(int Id) : IRequest<OrderResponseDto>;

    public class GetOrderByIdHandler(IOrderRepo order) : IRequestHandler<GetOrderById, OrderResponseDto>
    {
        public async Task<OrderResponseDto> Handle(GetOrderById request, CancellationToken cancellationToken)
        {
            return await order.GetOrderByIdAsync(request.Id, cancellationToken);
        }
    }
}

using InternProject.Application.Common.Interfaces;
using InternProject.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Features.Orders.Commands
{
    public record UpdateOrder(Order order) : IRequest<bool>;

    public class UpdateOrderHandler(IOrderRepo order) : IRequestHandler<UpdateOrder, bool>
    {
        public async Task<bool> Handle(UpdateOrder request, CancellationToken cancellationToken)
        {
            return await order.UpdateOrderAsync(request.order, cancellationToken);
        }
    };
}

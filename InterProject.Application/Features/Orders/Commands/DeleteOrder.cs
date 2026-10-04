using InternProject.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Features.Orders.Commands
{
    public record DeleteOrder(int Id):IRequest<bool>;

    public class DeleteOrderHandler(IOrderRepo order) : IRequestHandler<DeleteOrder, bool>
    {
        public async Task<bool> Handle(DeleteOrder request, CancellationToken cancellationToken)
        {
          return await order.DeleteOrderAsync(request.Id, cancellationToken);

        }
    };
}

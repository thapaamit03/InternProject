using InternProject.Application.Features.Orders.DTOs;
using InternProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Common.Interfaces
{
    public interface IOrderRepo
    {
        Task<int> CreateOrderAsync(Order order, CancellationToken cancellationToken);
        Task<OrderResponseDto> GetOrderByIdAsync(int id,CancellationToken cancellationToken);

        Task<List<OrderResponseDto>> GetAllOrdersAsync(CancellationToken cancellationToken);

        Task<bool> UpdateOrderAsync(Order order,CancellationToken cancellationToken);

        Task<bool> DeleteOrderAsync(int id,CancellationToken cancellationToken);

    }
}

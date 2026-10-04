using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Orders.DTOs;
using InternProject.Domain.Models;
using InternProject.Infrastructure.Data;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Infrastructure.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDbContext _context;
        public OrderRepo(ApplicationDbContext context)
        {
            _context = context;
        }

          public async  Task<int> CreateOrderAsync(Order order,CancellationToken cancellationToken)
            {
                var newOrder = new Order
                {
                    Id = order.Id,
                    UserId = order.UserId,
                    OrderItems = order.OrderItems,
                    OrderStatus = OrderStatus.Pending,
                    DiscountAmount = order.DiscountAmount,
                    TotalAmount = order.TotalAmount
                
                };

                _context.Orders.Add(newOrder);
                await _context.SaveChangesAsync();

                return newOrder.Id;
            }
           public async Task<OrderResponseDto> GetOrderByIdAsync(int id,CancellationToken cancellationToken)
            {
                var order = await _context.Orders
                    .AsNoTracking()
                    .Where(o => o.Id == id)
                    .Select(o => new OrderResponseDto
                    {
                        Id = o.Id,
                        TotalAmount = o.TotalAmount,
                        DiscountAmount = o.DiscountAmount
                    })
                    .FirstOrDefaultAsync(cancellationToken);
                if(order is null)
                {
                    throw new Exception($"Order with id {id} not found");
                }

            
                return order;

            }

            public async Task<List<OrderResponseDto>> GetAllOrdersAsync(CancellationToken cancellationToken)
            {
                return await _context.Orders.AsNoTracking()
                            .Select(o=> new OrderResponseDto
                            {
                                Id = o.Id,
                                TotalAmount = o.TotalAmount,
                                DiscountAmount = o.DiscountAmount   
                            }).ToListAsync(cancellationToken);
        }


            public async Task<bool> UpdateOrderAsync(Order order,CancellationToken cancellationToken)
            {
                var existingOrder = await _context.Orders.FirstOrDefaultAsync(o => o.Id == order.Id,cancellationToken);
                if(existingOrder is null)
                {
                    throw new Exception($"Order with id {order.Id} not found");
                }
                existingOrder.TotalAmount = order.TotalAmount;
                existingOrder.DiscountAmount = order.DiscountAmount;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }

            public async Task<bool> DeleteOrderAsync(int id,CancellationToken cancellationToken)
            {
                var existingOrder = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id,cancellationToken);
                if(existingOrder is null)
                {
                    throw new Exception($"Order with id {id} not found");
                };

                _context.Orders.Remove(existingOrder);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        public OrderStatus OrderStatus { get; set; }=OrderStatus.Pending;

        public decimal TotalAmount { get; set; }

        public decimal DiscountAmount { get; set; }

        public string UserId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        
    }

    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;

        public Order Order { get; set; } = null!;
    }
    public enum OrderStatus
    {
        Pending,
        Processing,
        Completed,
        Cancelled
    }
}

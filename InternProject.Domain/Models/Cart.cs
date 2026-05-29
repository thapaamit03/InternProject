using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Domain.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}

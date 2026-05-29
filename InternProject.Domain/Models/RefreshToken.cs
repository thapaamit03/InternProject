using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Domain.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; } = string.Empty;

        public DateTime ExpiryTime { get; set; }

        public bool IsRevoked { get; set; }

        public string UserId { get; set; } = string.Empty;

      
    }
}

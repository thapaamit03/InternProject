using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Features.Auth.DTOs
{
    public class RegisterResponseDto
    {
        public string Message { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}

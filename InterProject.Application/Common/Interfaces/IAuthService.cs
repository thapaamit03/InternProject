using InternProject.Application.Features.Auth.DTOs;
using InterProject.Application.Features.Auth.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternProject.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
    }
}

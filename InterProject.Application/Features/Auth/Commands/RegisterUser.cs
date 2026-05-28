using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Auth.DTOs;
using InterProject.Application.Features.Auth.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterProject.Application.Features.Auth.Commands
{
    public record RegisterUser(RegisterDto registerRequest) : IRequest<RegisterResponseDto>;
    
    public class RegisterUserHandler:IRequestHandler<RegisterUser,RegisterResponseDto>
    {
        private readonly IAuthService _service;
        public RegisterUserHandler(IAuthService service)
        {
            _service = service;
        }
        public async Task<RegisterResponseDto> Handle(RegisterUser request, CancellationToken cancellationToken)
        {
          if(string.IsNullOrWhiteSpace(request.registerRequest.Username)||string.IsNullOrWhiteSpace(request.registerRequest.Email)||
                string.IsNullOrWhiteSpace(request.registerRequest.Email))
            {
                throw new Exception("All fields are required");
            }

            return await _service.RegisterAsync(request.registerRequest); 
        }
    }
}

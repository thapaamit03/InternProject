using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Auth.DTOs;
using InterProject.Application.Features.Auth.DTOs;
using MediatR;

namespace InterProject.Application.Features.Auth.Commands
{
    public record LoginUser(LoginDto loginRequest) : IRequest<LoginResponseDto>;
    
    public class LoginUserHandler:IRequestHandler<LoginUser,LoginResponseDto>
    {
        private readonly IAuthService _service;
        public LoginUserHandler(IAuthService service)
        {
            _service = service;
        }
        public async Task<LoginResponseDto> Handle(LoginUser request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.loginRequest.Email) || string.IsNullOrWhiteSpace(request.loginRequest.Password))
            {
                throw new Exception("Email and password are required");
            }

          return await _service.LoginAsync(request.loginRequest);

           
        }

    }
}

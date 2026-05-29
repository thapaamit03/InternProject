using InternProject.Application.Common.Constants;
using InternProject.Application.Common.Interfaces;
using InternProject.Application.Features.Auth.DTOs;
using InternProject.Domain.Models;
using InternProject.Infrastructure.Data;
using InterProject.Application.Features.Auth.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace InternProject.Infrastructure.Identity
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _service;
        private readonly ApplicationDbContext _context;
        public AuthService(UserManager<ApplicationUser> userManager,IJwtService service,ApplicationDbContext context)
        {
            _userManager = userManager;
            _service = service;
            _context = context;
        }
       public async Task<RegisterResponseDto> RegisterAsync(RegisterDto registerDto)
        {
           var existingUser= await _userManager.FindByEmailAsync(registerDto.Email);
            if(existingUser is not null)
            {
                throw new BadHttpRequestException("user already exists");
            }

            var user = new ApplicationUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email
            };
          var result=await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("user creation failed");
            }
            await _userManager.AddToRoleAsync(user, Roles.Customer);
            return new RegisterResponseDto
            {
                Message = "user registered successfully",
                Email = user.Email,
                
            };
        }
        public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(loginDto.Email);
            if(existingUser is null)
            {
                throw new Exception("user not found");
            }

           var isPasswordValid= await _userManager.CheckPasswordAsync(existingUser, loginDto.Password);
            if (!isPasswordValid)
            {
                throw new Exception("Invalid credentials");
            }
          

            //generate token 
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,existingUser.Id),
                new  Claim(ClaimTypes.Name,existingUser.UserName),
                new Claim(ClaimTypes.Email,existingUser.Email)

            };

            var roles = await _userManager.GetRolesAsync(existingUser);
            if (roles is not null)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }
                var accessToken = _service.GenerateAccessToken(claims);
                var refreshToken = _service.GenerateRefreshToken();
            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                UserId = existingUser.Id,
                ExpiryTime = DateTime.UtcNow.AddDays(2)
            };
            _context.RefreshTokens.Add(refreshTokenEntity);
            await _context.SaveChangesAsync();
            return new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };  
        }
    }
}

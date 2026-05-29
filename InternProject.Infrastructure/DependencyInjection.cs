using InternProject.Application.Common.Interfaces;
using InternProject.Infrastructure.Data;
using InternProject.Infrastructure.Identity;
using InternProject.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace InternProject.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services,IConfiguration configuration)
        {
          
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
            ));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])
                        ),
                    RoleClaimType =ClaimTypes.Role
                };
            });
            services.AddAuthorization();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });
            
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService,JwtService>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<ICartRepo, CartRepo>();
            return services;
        }
    }
}

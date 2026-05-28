using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace InternProject.Application.Common.Interfaces
{
    public interface IJwtService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
       string GenerateRefreshToken();
    }
}

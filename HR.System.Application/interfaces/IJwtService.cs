using HR.System.Application.authentication;
using System.Security.Claims;

namespace HR.System.Application.interfaces;

public interface IJwtService
{
    AuthResponse GenerateToken(IEnumerable<Claim> claims);

    string GenerateRefreshToken();

    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);

}
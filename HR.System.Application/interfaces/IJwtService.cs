
using System.Security.Claims;
using HR.System.Application.authentication;

namespace HR.System.Application.interfaces;

public interface IJwtService
{
    Task<AuthResponse> GenerateTokenAsync(
        string userId,
        string email,
        string firstName,
        string lastName,
        IEnumerable<string> roles,
        CancellationToken cancellationToken = default);

    string GenerateRefreshToken();

    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}

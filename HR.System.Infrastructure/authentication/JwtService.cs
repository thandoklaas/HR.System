using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using HR.System.Application.authentication;
using HR.System.Application.interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HR.System.Infrastructure.authentication;

public sealed class JwtService : IJwtService
{
    private readonly JwtSettings _jwtSettings;

    public JwtService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<AuthResponse> GenerateTokenAsync(
        string userId,
        string email,
        string firstName,
        string lastName,
        IEnumerable<string> roles,
        CancellationToken cancellationToken = default)
    {
        var roleList = roles.ToList();

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userId),
            new(JwtRegisteredClaimNames.Email, email),

            new(ClaimTypes.NameIdentifier, userId),
            new(ClaimTypes.Email, email),
            new(ClaimTypes.GivenName, firstName),
            new(ClaimTypes.Surname, lastName)
        };

        foreach (var role in roleList)
        {
            claims.Add(
                new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256);

        var expiresAt =
            DateTime.UtcNow.AddMinutes(
                _jwtSettings.ExpirationMinutes);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: expiresAt,
            signingCredentials: credentials);

        var accessToken =
            new JwtSecurityTokenHandler().WriteToken(token);

        var refreshToken = GenerateRefreshToken();

        return await Task.FromResult(
            new AuthResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresAt = expiresAt,
                UserId = userId,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Roles = roleList
            });
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];

        using var rng =
            RandomNumberGenerator.Create();

        rng.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(
        string token)
    {
        var tokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = _jwtSettings.Audience,

                ValidateIssuer = true,
                ValidIssuer = _jwtSettings.Issuer,

                ValidateIssuerSigningKey = true,

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            _jwtSettings.SecretKey)),

                ValidateLifetime = false
            };

        var tokenHandler =
            new JwtSecurityTokenHandler();

        try
        {
            var principal =
                tokenHandler.ValidateToken(
                    token,
                    tokenValidationParameters,
                    out var securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken)
            {
                return null;
            }

            if (!jwtSecurityToken.Header.Alg
                    .Equals(
                        SecurityAlgorithms.HmacSha256,
                        StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            return principal;
        }
        catch
        {
            return null;
        }
    }
}


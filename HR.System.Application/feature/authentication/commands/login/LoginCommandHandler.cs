using HR.System.Application.authentication;
using HR.System.Application.interfaces;
using MediatR;

namespace HR.System.Application.feature.authentication.commands.login;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponse>
{
    private readonly IIdentityService _identityService;
    private readonly IJwtService _jwtService;

    public LoginCommandHandler(IIdentityService identityService, IJwtService jwtService)
    {
        _identityService = identityService;
        _jwtService = jwtService;
    }

    public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var identityResult =
            await _identityService.LoginAsync(
                request.Email, 
                request.Password, 
                cancellationToken);

        if (identityResult is null)
        {
            throw new UnauthorizedAccessException("Invalid email address or password.");
        }

        if (!identityResult.IsActive)
        {
            throw new UnauthorizedAccessException("This user account is inactive.");
        }

        var authResponse =
            await _jwtService.GenerateTokenAsync(
                identityResult.UserId,
                identityResult.Email,
                identityResult.FirstName,
                identityResult.LastName,
                identityResult.Roles,
                cancellationToken);

        return authResponse;
    }
}

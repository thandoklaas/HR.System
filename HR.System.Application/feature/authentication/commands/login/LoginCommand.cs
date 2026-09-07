using HR.System.Application.authentication;
using MediatR;

namespace HR.System.Application.feature.authentication.commands.login;

public sealed record LoginCommand(
    string Email,
    string Password) : IRequest<AuthResponse>;


namespace HR.System.Application.interfaces;

public interface IIdentityService
{
    Task<IdentityLoginResult?> LoginAsync(
        string email,
        string password,
        CancellationToken cancellationToken = default);
}

public sealed class IdentityLoginResult
{
    public string UserId { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public IEnumerable<string> Roles { get; init; } = [];

    public bool IsActive { get; init; }
}

using System.Security.Claims;

namespace HR.System.Application.authentication
{
    public sealed class TokenRequest
    {
        public required int UserId { get; init; }

        public required string UserName { get; init; }

        public required string Email { get; init; }

        public int? EmployeeId { get; init; }

        public IReadOnlyCollection<string> Roles { get; init; } = [];

        public IReadOnlyCollection<Claim> Claims { get; init; } = [];
    }
}
using HR.System.Application.interfaces;

namespace HR.System.Test.infrastructure;

internal class TestAuthenticationAdapter : IAuthenticationAdapter
{
    public string GetCurrentUserEmailAddress() => "tandoklaas0@gmail.com";

    public string GetCurrentUserId() => Guid.NewGuid().ToString();

    public string GetCurrentUserName() => "testusername";

    public string GetCurrentUserRoleId() => Guid.NewGuid().ToString();

    public string GetCurrentUserRoleName() => "testuserrole";

    public string GetCurrentUserFullName() => "Test User";

    public bool HasDataProfile() => true;
}

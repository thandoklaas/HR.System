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

    string IAuthenticationAdapter.GetCurrentUserName()
    {
        throw new NotImplementedException();
    }

    string IAuthenticationAdapter.GetCurrentUserId()
    {
        throw new NotImplementedException();
    }

    Task<string> IAuthenticationAdapter.GetCurrentUserRoleId()
    {
        throw new NotImplementedException();
    }

    Task<string> IAuthenticationAdapter.GetCurrentUserRoleName()
    {
        throw new NotImplementedException();
    }

    Task<string> IAuthenticationAdapter.GetCurrentUserEmailAddress() => Task.FromResult("tandoklaas0@gmail.com");

    Task<string> IAuthenticationAdapter.GetCurrentUserFullName()
    {
        throw new NotImplementedException();
    }

    bool IAuthenticationAdapter.HasDataProfile()
    {
        throw new NotImplementedException();
    }
}

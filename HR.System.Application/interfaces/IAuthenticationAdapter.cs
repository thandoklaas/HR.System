namespace HR.System.Application.interfaces;

public interface IAuthenticationAdapter
{
    string GetCurrentUserName();
    string GetCurrentUserId();
    Task<string> GetCurrentUserRoleId();
    Task<string> GetCurrentUserRoleName();
    Task<string> GetCurrentUserEmailAddress();
    Task<string> GetCurrentUserFullName();
    bool HasDataProfile();
}



namespace HR.System.Application.interfaces;

public interface IAuthenticationAdapter
{
    string GetCurrentUserName();
    string GetCurrentUserId();
    string GetCurrentUserRoleId();
    string GetCurrentUserRoleName();
    string GetCurrentUserEmailAddress();
    string GetCurrentUserFullName();
    bool HasDataProfile();
}



using HR.System.Application.interfaces;
using HR.System.Infrastructure.identity;
using HR.System.Infrastructure.persistance;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
//using System.Data.Entity;

namespace HR.System.Infrastructure.authentication
{
    public class LocalAuthenticationAdapter : IAuthenticationAdapter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly UserStore<IdentityUser> _userManager ;

        public LocalAuthenticationAdapter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

            _userManager =new UserStore<IdentityUser>(new LeaveDbContext());
        }
        //public string GetCurrentUserName() => _httpContextAccessor?.HttpContext?.User?.Identity?.Name;

        public string GetCurrentUserName() =>
            _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "System";

        public async Task<string> GetCurrentUserFullName()
        {
            var user = await GetUser();

            return user.FirstName + " " + user.LastName;
        }

        public string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext?
                .User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            return userId ?? string.Empty;
        }


        public async Task<string> GetCurrentUserRoleId()
        {
            var user = await GetUser();

            return user == null 
                ? string.Empty
                : user.Id.ToString();
        }

        public async Task<string> GetCurrentUserRoleName()
        {
            var result = await GetRole();
               
            return result.UserName ?? string.Empty;
        }

        public async Task<string> GetCurrentUserEmailAddress()
        {
            var result = await GetUser();

            return result.Email ?? string.Empty;
        }

        public bool HasDataProfile()
        {
            return true;
            //using (var context = new LeaveDbContext())
            //{
            //    var userId = GetCurrentUserId();
            //    var roleId = GetCurrentUserRoleId();

            //    return userId != null && roleId != null;
            //}
        }

        protected async Task<ApplicationUser> GetUser()
        {

            var result = await _userManager.FindByIdAsync(GetCurrentUserId());
            if (result == null)
            {
                throw new Exception("User not found");
            }
            return (ApplicationUser)result;
        }

        protected async Task<IdentityUser> GetRole()
        {
            var userId = GetCurrentUserId();
            var data = await _userManager.FindByIdAsync(userId);
    
            return data;
        }
    }
}

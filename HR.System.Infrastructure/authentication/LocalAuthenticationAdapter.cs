using HR.System.Application.interfaces;
using HR.System.Infrastructure.identity;
using HR.System.Infrastructure.persistance;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using IdentityRole = Microsoft.AspNet.Identity.EntityFramework.IdentityRole;
using IdentityUser = Microsoft.AspNet.Identity.EntityFramework.IdentityUser;
using Microsoft.AspNet.Identity;

namespace HR.System.Infrastructure.authentication
{
    public class LocalAuthenticationAdapter : IAuthenticationAdapter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LocalAuthenticationAdapter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetCurrentUserName() => _httpContextAccessor.HttpContext.User.Identity.GetUserName();

        public string GetCurrentUserFullName()
        {
            var user = GetUser();
            return user.FirstName + " " + user.LastName;
        }

        public string GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext?
                .User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            return userId ?? string.Empty;
        }


        public string GetCurrentUserRoleId()
        {
            var user = GetUser();


            return user == null || !user.Roles.Any()
                ? string.Empty
                : user.Roles.First().Id.ToString();
        }

        public string GetCurrentUserRoleName() => GetRole()?.Name ?? string.Empty;

        public string GetCurrentUserEmailAddress() => GetUser().Email;

        public bool HasDataProfile()
        {
            using (var context = new LeaveDbContext())
            {
                var userId = GetCurrentUserId();
                var roleId = GetCurrentUserRoleId();

                return userId != null && roleId != null;
            }
        }

        protected ApplicationUser GetUser()
        {
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new IdentityDbContext()));
           var result = userManager.FindById(GetCurrentUserId());
            return (ApplicationUser)result;
        }

        protected ApplicationRole GetRole()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new IdentityDbContext()));
            return (ApplicationRole)roleManager.FindById(GetCurrentUserRoleId());
        }
    }
}

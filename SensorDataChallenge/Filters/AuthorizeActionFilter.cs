using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SensorDataChallenge.Data;
using SensorDataChallenge.Enums;
using System.Linq;
using System.Security.Claims;

namespace SensorDataChallenge.Filters
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        private readonly SensorDataDbContext _context;
        private readonly PermissionEnum _item;

        public AuthorizeActionFilter(SensorDataDbContext context, PermissionEnum item)
        {
            _context = context;
            _item = item;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool isAuthorized = IsAuthorized(context.HttpContext.User, _item);

            if (!isAuthorized)
            {
                context.Result = new ForbidResult();
            }
        }

        private bool IsAuthorized(ClaimsPrincipal user, PermissionEnum item)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            return _context.ApplicationUser.Any(x => x.Id == userId && x.Permission.Any(x => x.Id == (int)item));
        }
    }
}

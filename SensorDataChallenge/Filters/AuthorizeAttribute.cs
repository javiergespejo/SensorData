using Microsoft.AspNetCore.Mvc;
using SensorDataChallenge.Enums;

namespace SensorDataChallenge.Filters
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(PermissionEnum item)
        : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { item };
        }
    }
}

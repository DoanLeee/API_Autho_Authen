using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;
using System.Security.Claims;

namespace Demo_API.Attribute
{
    public class sieuphamAuthorizedAttribute : TypeFilterAttribute
    {
        public string RoleName { get; set; }
        public string ActionValue { get; set; }
        public sieuphamAuthorizedAttribute( string roleName, string actionValue) : base(typeof(sieuphamAuthoziredFilter))
        {
            RoleName = roleName;
            ActionValue = actionValue;
            Arguments= new object[] {RoleName,ActionValue };
        }
        public class sieuphamAuthoziredFilter : IAuthorizationFilter
        {
            public string RoleName { get; set; }
            public string ActionValue { get; set; }
            public sieuphamAuthoziredFilter(string roleName, string actionValue) 
            {
                RoleName = roleName;
                ActionValue = actionValue;
            }
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                if (!CanAccessToAction(context.HttpContext))
                    context.Result = new ForbidResult();

            }
            private bool CanAccessToAction(HttpContext httpContext)
            {
                var roles = httpContext.User.FindFirstValue(ClaimTypes.Role);
                if (roles.Equals(RoleName))
                    { 
                    return true;
                }

                return false;
            }
        }
         

    }
}

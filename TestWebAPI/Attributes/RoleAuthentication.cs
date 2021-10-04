using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TestWebAPI.Attributes
{
    public class RoleAuthenticationAttribute : TypeFilterAttribute
    {
        public RoleAuthenticationAttribute(int roleId) : base(typeof(RoleAuthenticationFilter))
        {
            Arguments = new object[] { roleId };
        }
    }
    public class RoleAuthenticationFilter : IAuthorizationFilter
    {
        readonly int _roleId;

        public RoleAuthenticationFilter(int roleId)
        {
            _roleId = roleId;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            ClaimsIdentity claimsIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var currentRoleId = Convert.ToInt32(claimsIdentity.FindFirst("RoleId").Value);
                if (currentRoleId != _roleId)
                {
                    context.Result = new ForbidResult();
                }
            }
            else
            {
                context.Result = new ForbidResult();
            }
        }
    }

    public struct Role
    {
        public const int Admin = 1;
        public const int Guest = 2;
    }
}

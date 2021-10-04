using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public int UserId
        {
            get
            {
                ClaimsIdentity claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    IEnumerable<Claim> claims = claimsIdentity.Claims;
                    var UserId = claimsIdentity.FindFirst("UserId").Value;
                    return Convert.ToInt32(UserId);
                }
                return 0;
            }
        }

        public string Name
        {
            get
            {
                ClaimsIdentity claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    IEnumerable<Claim> claims = claimsIdentity.Claims;
                    var UserName = claimsIdentity.FindFirst("Name").Value;
                    return Convert.ToString(UserName);
                }
                return string.Empty;
            }
        }
        public int RoleId
        {
            get
            {
                ClaimsIdentity claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    IEnumerable<Claim> claims = claimsIdentity.Claims;
                    var UserName = claimsIdentity.FindFirst("RoleId").Value;
                    return Convert.ToInt32(UserName);
                }
                return 0;
            }
        }

    }
}

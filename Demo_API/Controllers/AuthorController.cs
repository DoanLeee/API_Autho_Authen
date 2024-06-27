using Demo_API.Models.RequestModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Demo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        [HttpGet("unauthorized")]
        public IActionResult GetUnauthorized()
        {
            return Unauthorized();
        }

        [HttpGet("unauthorized-v2")]
        public IActionResult GetUnauthorizedV2()
        {
            return Unauthorized();
        }
        [HttpGet("forbidden")]
        public IActionResult GetForbindden()
        {
            return Forbid();
        }
        [HttpPost("login-cookie")]
        public async Task<IActionResult> LoginCookie([FromBody] UserRequestModels userRequestModels)
        {

            //check user
            //get role
            string roleName=string.Empty;
            if (userRequestModels.UserName.EndsWith("Administrator"))
                roleName = "Administrator";
            else if(userRequestModels.UserName.EndsWith("Admin"))
                roleName = "Admin";
            else
                roleName = "Guest";
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userRequestModels.UserName),
                new Claim(ClaimTypes.Role, "Guest"),
                new Claim("FullName", "Le Nguyen To Doan")

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var authPoperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.UtcNow.AddDays(1),
                IsPersistent = true,

            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authPoperties);
            return Ok("Login success with cookie");

        }
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
          await  HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("Logout success with cookie");

        }
    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eShop.Web.Controllers
{
    public class AuthenticateController : ControllerBase
    {
        [Route("/authenticate")]
        public async Task<IActionResult> Authenticate([FromQuery] string usr, [FromQuery] string pwd)
        {
            if (usr == "admin" && pwd == "adminadmin")
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, usr),
                    new Claim(ClaimTypes.Email, "admin@eshop.com"),
                    new Claim(ClaimTypes.HomePhone, "12345678")
                };

                var userIdentity = new ClaimsIdentity(userClaims, "eShop.CookieAuth"); // this is critical

                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync("eShop.CookieAuth", userPrincipal);
            }

            return Redirect("/outstandingorders");
        }

        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/outstandingorders");
        }
    }
}

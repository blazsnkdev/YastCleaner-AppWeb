using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace YAST_CLENAER_WEB.Controllers
{
    public class AuthController : Controller
    {

        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Login(string returnUrl = "/")
        {
            var autenticationProperties = new AuthenticationProperties
            {
                RedirectUri = returnUrl
            };
            return Challenge(autenticationProperties, "Auth0");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var domain = _configuration["Auth0:Domain"];
            var clientId = _configuration["Auth0:ClientId"];

            var callbackUrl = Url.Action("Index", "Home", null, Request.Scheme);

            var logoutUrl = $"https://{domain}/v2/logout?client_id={clientId}&returnTo={Uri.EscapeDataString(callbackUrl!)}";

            return SignOut(new AuthenticationProperties
            {
                RedirectUri = logoutUrl
            },

            CookieAuthenticationDefaults.AuthenticationScheme);

        }

    }
}

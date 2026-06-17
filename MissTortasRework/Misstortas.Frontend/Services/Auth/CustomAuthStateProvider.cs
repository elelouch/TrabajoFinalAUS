using Microsoft.AspNetCore.Components.Authorization;
using Misstortas.Frontend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Misstortas.Frontend.Services.Auth
{
    public class CustomAuthStateProvider(IHttpContextAccessor httpContext) : AuthenticationStateProvider
    {
        private AuthenticationState? _cachedState;

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_cachedState is not null)
                return Task.FromResult(_cachedState);

            try
            {
                var context = httpContext.HttpContext;
                var token = context?.Request.Cookies[AuthConstants.CookieAccessToken];

                if (token is not null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                    var claims = jsonToken!.Claims.ToList();
                    var claimsIdentity = new ClaimsIdentity(claims, "jwt");
                    var user = new ClaimsPrincipal(claimsIdentity);
                    _cachedState = new AuthenticationState(user);
                    return Task.FromResult(_cachedState);
                }

                _cachedState = new AuthenticationState(new ClaimsPrincipal());
                return Task.FromResult(_cachedState);
            }
            catch (Exception)
            {
                _cachedState = new AuthenticationState(new ClaimsPrincipal());
                return Task.FromResult(_cachedState);
            }
        }
    }
}

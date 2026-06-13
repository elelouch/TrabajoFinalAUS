using Microsoft.AspNetCore.Components.Authorization;
using Misstortas.Frontend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Misstortas.Frontend.Services.Auth
{
    public class CustomAuthStateProvider(IHttpContextAccessor httpContext) : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var token = httpContext.HttpContext!.Request.Cookies[AuthConstants.CookieAccessToken];
                if (token is not null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                    var claims = new List<Claim>();
                    foreach (var claim in jsonToken!.Claims)
                    {
                        claims.Add(new Claim(claim.Type, claim.Value));
                    }
                    var claimsIdentity = new ClaimsIdentity(claims, "jwt");
                    var user = new ClaimsPrincipal(claimsIdentity);
                    return Task.FromResult(new AuthenticationState(user));
                }
                return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
            } 
            catch (Exception)
            {
                return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
            }

        }
    }
}

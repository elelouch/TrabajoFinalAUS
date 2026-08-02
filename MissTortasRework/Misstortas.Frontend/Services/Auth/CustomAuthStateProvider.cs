using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Misstortas.Frontend.Services.Auth
{
    public class CustomAuthStateProvider(IHttpContextAccessor httpContext, IAuthService authService) : AuthenticationStateProvider
    {
        private AuthenticationState? _cachedState;
        private DateTime? _cachedExpiry;
        private readonly SemaphoreSlim _refreshLock = new(1, 1);

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Only trust the cache while it's still within the token's validity window
            if (_cachedState is not null && _cachedExpiry is not null && _cachedExpiry > DateTime.UtcNow)
                return _cachedState;

            await _refreshLock.WaitAsync();
            try
            {
                // Re-check: another call may have already refreshed while we waited
                if (_cachedState is not null && _cachedExpiry is not null && _cachedExpiry > DateTime.UtcNow)
                    return _cachedState;

                var context = httpContext.HttpContext;
                var token = context?.Request.Cookies[AuthConstants.CookieAccessToken];
                var refreshToken = context?.Request.Cookies[AuthConstants.CookieRefreshToken];

                if (token is null)
                    return SetAnonymous();

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jsonToken is null || jsonToken.ValidTo < DateTime.UtcNow)
                {
                    var refreshed = await authService.RefreshTokenAsync(refreshToken ?? "");

                    if (refreshed is not null &&
                        handler.ReadToken(refreshed.AccessToken) is JwtSecurityToken newAccessToken)
                    {
                        context?.Response.Cookies.Append(
                            AuthConstants.CookieAccessToken,
                            refreshed.AccessToken,
                            new CookieOptions
                            {
                                Expires = newAccessToken.ValidTo,
                                HttpOnly = true,
                                Secure = true,
                                SameSite = SameSiteMode.Strict
                            });

                        context?.Response.Cookies.Append(
                            AuthConstants.CookieRefreshToken,
                            refreshed.RefreshToken,
                            new CookieOptions
                            {
                                Expires = DateTimeOffset.UtcNow.AddDays(7), // match your actual refresh token lifetime
                                HttpOnly = true,
                                Secure = true,
                                SameSite = SameSiteMode.Strict
                            });

                        var identity = new ClaimsIdentity(newAccessToken.Claims, "jwt");
                        return SetAuthenticated(new ClaimsPrincipal(identity), newAccessToken.ValidTo);
                    }

                    context?.Response.Cookies.Delete(AuthConstants.CookieAccessToken);
                    context?.Response.Cookies.Delete(AuthConstants.CookieRefreshToken);
                    return SetAnonymous();
                }

                var claimsIdentity = new ClaimsIdentity(jsonToken.Claims, "jwt");
                return SetAuthenticated(new ClaimsPrincipal(claimsIdentity), jsonToken.ValidTo);
            }
            catch (Exception)
            {
                return SetAnonymous();
            }
            finally
            {
                _refreshLock.Release();
            }
        }

        private AuthenticationState SetAuthenticated(ClaimsPrincipal user, DateTime expiry)
        {
            _cachedState = new AuthenticationState(user);
            _cachedExpiry = expiry;
            return _cachedState;
        }

        private AuthenticationState SetAnonymous()
        {
            _cachedState = new AuthenticationState(new ClaimsPrincipal());
            _cachedExpiry = null;
            return _cachedState;
        }

        // Call after login/logout so components react immediately
        public void NotifyUserAuthentication()
        {
            _cachedState = null;
            _cachedExpiry = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}

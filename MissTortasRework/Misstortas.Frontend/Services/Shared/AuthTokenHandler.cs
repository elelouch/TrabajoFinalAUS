using Misstortas.Frontend.Services.Auth;

namespace Misstortas.Frontend.Services.Shared
{
    public class AuthTokenHandler(IHttpContextAccessor httpContextAccessor) : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var token = httpContextAccessor.HttpContext?
                .Request.Cookies[AuthConstants.CookieAccessToken];

            //if (!string.IsNullOrEmpty(token))
            //{
            //    //request.Headers.Add(AuthConstants.CookieAccessToken, token);
            //    request.Headers.Add("Cookie", $"{AuthConstants.CookieAccessToken}={token}");
            //}
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Remove("Cookie");
                request.Headers.TryAddWithoutValidation("Cookie", $"{AuthConstants.CookieAccessToken}={token}");
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}

using MissTortas.Desktop.Services.AuthService;
using MissTortas.Desktop.Services.DTO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace MissTortas.Desktop.Services.Shared
{
    public sealed class MissTortasHttpClient : IMissTortasHttpClient
    {
        private readonly HttpClient httpClient = new();
        private readonly SemaphoreSlim refreshLock = new(1, 1);
        private readonly string ApiBaseUrl;

        public MissTortasHttpClient(string apiBaseUrl)
        {
            this.ApiBaseUrl = apiBaseUrl;
            ConfigureClient();
            SetAuthorizationHeader();
        }

        private void ConfigureClient()
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            httpClient.BaseAddress = new Uri(ApiBaseUrl);
        }

        private void SetAuthorizationHeader()
        {
            httpClient.DefaultRequestHeaders.Authorization =
                !string.IsNullOrEmpty(MissTortasToken.AccessToken)
                    ? new AuthenticationHeaderValue("Bearer", MissTortasToken.AccessToken)
                    : null;
        }

        public Task<T?> GetAsync<T>(string endpoint) =>
            ExecuteWithRetry<T>(() => httpClient.GetAsync(endpoint));

        public Task<T?> PostAsync<T>(string endpoint, object? data = null) =>
            ExecuteWithRetry<T>(() => httpClient.PostAsJsonAsync(endpoint, data));

        public Task<T?> PutAsync<T>(string endpoint, object? data = null) =>
            ExecuteWithRetry<T>(() => httpClient.PutAsJsonAsync(endpoint, data));

        public Task<T?> DeleteAsync<T>(string endpoint) =>
            ExecuteWithRetry<T>(() => httpClient.DeleteAsync(endpoint));

        /// <summary>
        /// Sends the request via <paramref name="sendRequest"/>. On a 401, attempts a token
        /// refresh (only once per call, shared across concurrent callers) and retries the
        /// request exactly one time with the refreshed token.
        /// </summary>
        private async Task<T?> ExecuteWithRetry<T>(Func<Task<HttpResponseMessage>> sendRequest)
        {
            var response = await sendRequest();

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var refreshed = await TryRefreshTokenAsync();
                if (refreshed)
                {
                    response.Dispose();
                    response = await sendRequest(); // retry once, with the new Authorization header
                }
            }

            return await HandleResponse<T>(response);
        }

        /// <summary>
        /// Refreshes the access token. Safe to call from concurrent requests — only the first
        /// caller actually hits the network; the rest wait and reuse its result.
        /// </summary>
        private async Task<bool> TryRefreshTokenAsync()
        {
            await refreshLock.WaitAsync();
            try
            {
                // another concurrent request may have already refreshed while we waited
                var refreshToken = MissTortasToken.RefreshToken;
                if (string.IsNullOrEmpty(refreshToken))
                    return false;

                var refreshRequest = new TokenRefreshRequest { RefreshToken = refreshToken };
                var newResponse = await httpClient.PostAsJsonAsync("auth/refresh", refreshRequest);

                if (!newResponse.IsSuccessStatusCode)
                    return false;

                var refreshResponse = await newResponse.Content.ReadFromJsonAsync<TokenRefreshResponse>();
                if (refreshResponse is null)
                    return false;

                MissTortasToken.AccessToken = refreshResponse.AccessToken;
                MissTortasToken.RefreshToken = refreshResponse.RefreshToken;
                SetAuthorizationHeader(); // update the default header so the retry picks it up

                return true;
            }
            finally
            {
                refreshLock.Release();
            }
        }

        private async Task<T?> HandleResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                if (response.Content.Headers.ContentLength == 0)
                    return default;

                return await response.Content.ReadFromJsonAsync<T>();
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new SessionExpiredException("Unauthorized.");

            var problem = await TryReadProblemDetailsAsync(response);
            throw new ApiException(problem, response.StatusCode);
        }

        private static async Task<ProblemDetailsDto> TryReadProblemDetailsAsync(HttpResponseMessage response)
        {
            try
            {
                var problem = await response.Content.ReadFromJsonAsync<ProblemDetailsDto>();
                if (problem is not null)
                    return problem;
            }
            catch (JsonException)
            {
                // body wasn't ProblemDetails-shaped
            }

            return new ProblemDetailsDto
            {
                Title = "Request failed",
                Status = (int)response.StatusCode,
                Detail = response.ReasonPhrase
            };
        }

        public Task<T?> PostAsFormAsync<T>(string endpoint, object data, List<(Stream, string)> files = null) =>
    ExecuteWithRetry<T>(() => SendFormDataAsync(endpoint, data, files));

        private async Task<HttpResponseMessage> SendFormDataAsync(
                string endpoint,
                object data,
                List<(Stream stream, string fileName)> files
            )
        {
            using var content = new MultipartFormDataContent();

            // Add form fields
            if (data != null)
            {
                var properties = data.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(data);
                    if (value != null && !(value is string str && string.IsNullOrEmpty(str)))
                    {
                        content.Add(new StringContent(value.ToString() ?? ""), prop.Name);
                    }
                }
            }

            if (files != null)
            {
                foreach (var (stream, fileName) in files)
                {
                    var streamContent = new StreamContent(stream);
                    content.Add(streamContent, "files", fileName);
                }
            }

            // Temporarily remove the Accept header for this multipart request
            var acceptHeader = httpClient.DefaultRequestHeaders.Accept.FirstOrDefault();
            httpClient.DefaultRequestHeaders.Accept.Clear();

            try
            {
                return await httpClient.PostAsync(endpoint, content);
            }
            finally
            {
                // Restore the Accept header
                if (acceptHeader != null)
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(acceptHeader);
                }
                else
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json")
                    );
                }
            }
        }
    }
}
using MissTortas.Desktop.Services.AuthService;
using MissTortas.Desktop.Services.DTO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MissTortas.Desktop.Services.Shared
{
    public sealed class MissTortasHttpClient : IMissTortasHttpClient
    {
        private readonly HttpClient httpClient = new();

        public MissTortasHttpClient()
        {
            ConfigureClient();
            SetAuthorizationHeader();
        }

        private void ConfigureClient()
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            httpClient.BaseAddress = new Uri("https://localhost:7245/");
        }
        private void SetAuthorizationHeader()
        {
            if (!string.IsNullOrEmpty(MissTortasToken.AccessToken))
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", MissTortasToken.AccessToken);
            }
            else
            {
                httpClient.DefaultRequestHeaders.Authorization = null;
            }
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            var response = await httpClient.GetAsync(endpoint);
            return await HandleResponse<T>(response);
        }

        public async Task<T?> PostAsync<T>(string endpoint, object? data = null)
        {
            var response = await httpClient.PostAsJsonAsync(endpoint, data);
            return await HandleResponse<T>(response);
        }

        public async Task<T?> PutAsync<T>(string endpoint, object? data = null)
        {
            var response = await httpClient.PutAsJsonAsync(endpoint, data);
            return await HandleResponse<T>(response);
        }

        public async Task<T?> DeleteAsync<T>(string endpoint)
        {
            var response = await httpClient.DeleteAsync(endpoint);
            return await HandleResponse<T>(response);
        }

        private async Task<T?> HandleResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                if (response.Content.Headers.ContentLength == 0)
                    return default;

                return await response.Content.ReadFromJsonAsync<T>();
            }

            var refreshToken = MissTortasToken.RefreshToken;
            if (response.StatusCode == HttpStatusCode.Unauthorized && !string.IsNullOrEmpty(refreshToken))
            {
                var refreshRequest = new TokenRefreshRequest { RefreshToken = refreshToken };
                var newResponse = await this.httpClient.PostAsJsonAsync("auth/refresh", refreshRequest);
                var refreshResponse = await newResponse.Content.ReadFromJsonAsync<TokenRefreshResponse>();
                if (refreshResponse is not null)
                {
                    MissTortasToken.AccessToken = refreshResponse.AccessToken;
                    MissTortasToken.RefreshToken = refreshResponse.RefreshToken;
                }
            }

            var error = await response.Content.ReadFromJsonAsync<ErrorDTO>();
            throw new HttpRequestException(error?.Message ?? "Request failed");
        }
    }
}
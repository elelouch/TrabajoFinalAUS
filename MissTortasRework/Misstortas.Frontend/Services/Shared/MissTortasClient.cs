using Microsoft.AspNetCore.Mvc;

namespace Misstortas.Frontend.Services.Shared
{
    public class MissTortasClient(HttpClient httpClient) : IMissTortasClient
    {
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


        public async Task<T?> PatchAsync<T>(string endpoint, object? data = null)
        {
            var response = await httpClient.PatchAsJsonAsync(endpoint, data);
            return await HandleResponse<T>(response);
        }

        protected async Task<T?> HandleResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                if (response.Content.Headers.ContentLength == 0)
                    return default;

                return await response.Content.ReadFromJsonAsync<T>();
            }

            ProblemDetails? problem = null;

            try
            {
                problem = await response.Content.ReadFromJsonAsync<ProblemDetails>();
            }
            catch
            {
                // Ignore deserialization errors and fall back below.
            }

            var message =
                problem?.Detail ??
                problem?.Title ??
                response.ReasonPhrase ??
                "An unexpected error occurred.";

            throw new HttpRequestException(
                message,
                null,
                response.StatusCode);
        }

    }
}

using Misstortas.Frontend.Services.DTO;

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

        protected async Task<T?> HandleResponse<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                if (response.Content.Headers.ContentLength == 0)
                    return default;

                return await response.Content.ReadFromJsonAsync<T>();
            }

            var error = await response.Content.ReadFromJsonAsync<ErrorDTO>();
            throw new HttpRequestException(error?.Message ?? "Request failed");
        }
    }
}

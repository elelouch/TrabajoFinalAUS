namespace MissTortas.Desktop.Services.Shared
{
    public interface IMissTortasHttpClient
    {
        public Task<T?> GetAsync<T>(string endpoint);
        public Task<T?> PostAsync<T>(string endpoint, object? data = null);
        public Task<T?> PutAsync<T>(string endpoint, object? data = null);
        public Task<T?> PatchAsync<T>(string endpoint, object? data = null);
        public Task<T?> DeleteAsync<T>(string endpoint);
    }
}

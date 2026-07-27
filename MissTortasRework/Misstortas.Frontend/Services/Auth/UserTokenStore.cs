namespace Misstortas.Frontend.Services.Auth
{
    public class UserTokenStore(HttpClient httpClient) : IUserTokenStore
    {
        private readonly SemaphoreSlim refreshLock = new(1, 1);

        public string? AccessToken { get; private set; }
        public string? RefreshToken { get; private set; }

        public void SetTokens(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public void Clear()
        {
            AccessToken = null;
            RefreshToken = null;
        }

        public async Task<bool> TryRefreshAsync()
        {
            await refreshLock.WaitAsync();
            try
            {
                if (string.IsNullOrEmpty(RefreshToken))
                    return false;

                var response = await httpClient.PostAsJsonAsync("/auth/refresh", new { RefreshToken });

                if (!response.IsSuccessStatusCode)
                {
                    Clear();
                    return false;
                }

                var result = await response.Content.ReadFromJsonAsync<SigninResponseDTO>();
                if (result is null || string.IsNullOrEmpty(result.AccessToken))
                {
                    Clear();
                    return false;
                }

                AccessToken = result.AccessToken;
                RefreshToken = result.RefreshToken;
                return true;
            }
            finally
            {
                refreshLock.Release();
            }
        }
    }
}

namespace Misstortas.Frontend.Services.Auth
{
    public interface IUserTokenStore
    {
        public string? AccessToken { get; }
        public string? RefreshToken { get; }
        public void SetTokens(string accessToken, string refreshToken);
        public void Clear();
        public Task<bool> TryRefreshAsync();
    }
}

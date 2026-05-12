namespace Misstortas.Frontend.Services.Auth
{
    public interface IAuthClient
    {
        public Task SignInUserAsync(UserSignin userSignin);
        public Task TestEndpoint();
    }
}

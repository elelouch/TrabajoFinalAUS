namespace Misstortas.Frontend.Services.Auth
{
    public interface IAuthClient
    {
        public Task<SigninDTO> SignInUserAsync(UserSignin userSignin);
    }
}

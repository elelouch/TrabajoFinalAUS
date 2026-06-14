namespace Misstortas.Frontend.Services.Auth
{
    public interface IAuthService
    {
        public Task<SigninDTO> SignInUserAsync(UserSignin userSignin);
    }
}

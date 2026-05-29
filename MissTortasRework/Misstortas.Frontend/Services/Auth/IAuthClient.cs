namespace Misstortas.Frontend.Services.Auth
{
    public interface IAuthClient
    {
        public Task<SigninResponseDTO> SignInUserAsync(UserSignin userSignin);
    }
}

namespace Misstortas.Frontend.Services.Auth
{
    public interface IAuthService
    {
        public Task<SigninResponseDTO> SignInUserAsync(UserSignin userSignin);
        public Task<SignupResponseDTO> SignUpUserAsync(UserSignup userSignin);
        public Task SignOut();
    }
}

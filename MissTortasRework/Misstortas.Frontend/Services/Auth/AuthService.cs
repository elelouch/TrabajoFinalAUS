using Misstortas.Frontend.Services.Shared;

namespace Misstortas.Frontend.Services.Auth
{
    public class AuthService(IMissTortasClient missTortasClient) : IAuthService
    {
        public async Task<RefreshResponseDTO?> RefreshTokenAsync(string refreshToken)
        {
            var body = await missTortasClient.PostAsync<RefreshResponseDTO>("/auth/refresh", new { refreshToken });
            return body;
        }

        public async Task<SigninResponseDTO> SignInUserAsync(UserSignin userSignin)
        {
            var body = await missTortasClient.PostAsync<SigninResponseDTO>("/auth/signin", userSignin);
            return body!;
        }
        public async Task SignOut()
        {
            await missTortasClient.PostAsync<object>("/auth/signout");
        }

        public async Task<SignupResponseDTO> SignUpUserAsync(UserSignup userSignup)
        {
            var body = await missTortasClient.PostAsync<SignupResponseDTO>("/auth/signup", userSignup);
            return body!;
        }
    }
}
using Misstortas.Frontend.Services.Shared;

namespace Misstortas.Frontend.Services.Auth
{
    public class AuthService(IMissTortasClient missTortasClient) : IAuthService
    {
        public async Task<SigninDTO> SignInUserAsync(UserSignin userSignin)
        {
            var body = await missTortasClient.PostAsync<SigninResponseDTO>("/auth/signin", userSignin);

            return new SigninDTO
            {
                AccessToken = body?.AccessToken ?? "",
                RefreshToken = body?.RefreshToken ?? ""
            };
        }
    }
}
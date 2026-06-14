using Misstortas.Frontend.Services.DTO;
using Misstortas.Frontend.Services.Shared;

namespace Misstortas.Frontend.Services.Auth
{
    public class AuthService(IMissTortasClient missTortasClient) : IAuthService
    {
        public async Task<SigninDTO> SignInUserAsync(UserSignin userSignin)
        {
            try
            {
                var body = await missTortasClient.PostAsync<SigninResponseDTO>("/auth/signin", userSignin);

                return new SigninDTO
                {
                    Success = true,
                    AccessToken = body?.AccessToken ?? ""
                };
            }
            catch (HttpRequestException ex)
            {
                return new SigninDTO
                {
                    Success = false,
                    Result = ex.Message
                };
            }
        }
    }
}
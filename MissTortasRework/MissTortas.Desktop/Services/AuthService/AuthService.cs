using MissTortas.Desktop.Services.DTO;
using MissTortas.Desktop.Services.Shared;

namespace MissTortas.Desktop.Services.AuthService
{
    public class AuthService(IMissTortasHttpClient httpClient) : IAuthService
    {
        public async Task<UserMetadata?> GetUserMetadataAsync(SignupRequest signUpDTO)
        {
            var userMetadata = await httpClient.GetAsync<UserMetadata>("auth/me");
            return userMetadata;
        }

        public async Task SignInAsync(SigninRequest signInDTO)
        {
            var res = await httpClient.PostAsync<SigninResponse>("auth/signin", signInDTO);
            MissTortasToken.AccessToken = res?.AccessToken;
            MissTortasToken.RefreshToken = res?.RefreshToken;
        }

        public async Task<string?> SignUpAsync(SignupRequest signUpDTO)
        {
            var res = await httpClient.PostAsync<SignupResponse>("auth/signup", signUpDTO);
            return res?.UserId;
        }
    }
}

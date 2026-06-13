using Misstortas.Frontend.Services.DTO;
using System.Text;
using System.Text.Json;

namespace Misstortas.Frontend.Services.Auth
{
    public class AuthClient(HttpClient httpClient) : IAuthClient
    {
        public async Task<SigninDTO> SignInUserAsync(UserSignin userSignin)
        {
            var res = await httpClient.PostAsJsonAsync("/auth/signin", userSignin);
            if (!res.IsSuccessStatusCode)
            {
                var responseBody = await res.Content.ReadFromJsonAsync<ErrorDTO>();
                var response = new SigninDTO
                {
                    Success = res.IsSuccessStatusCode,
                    Result = responseBody!.Message
                };
                return response;
            }
            var body = await res.Content.ReadFromJsonAsync<SigninResponseDTO>();
            if(body is null)
            {
                return new SigninDTO { Success = res.IsSuccessStatusCode };
            }
            return new SigninDTO { Success = res.IsSuccessStatusCode, AccessToken = body!.AccessToken };
        }
    }
}

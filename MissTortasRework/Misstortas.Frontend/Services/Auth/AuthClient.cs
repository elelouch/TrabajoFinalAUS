using Misstortas.Frontend.Services.DTO;
using System.Text;
using System.Text.Json;

namespace Misstortas.Frontend.Services.Auth
{
    public class AuthClient(HttpClient httpClient) : IAuthClient
    {
        public async Task<SigninResponseDTO> SignInUserAsync(UserSignin userSignin)
        {
            var res = await httpClient.PostAsJsonAsync("/auth/signin", userSignin);
            if (!res.IsSuccessStatusCode)
            {
                var responseBody = await res.Content.ReadFromJsonAsync<ErrorDTO>();
                var response = new SigninResponseDTO
                {
                    Success = res.IsSuccessStatusCode,
                    Result = responseBody!.Message
                };
                return response;
            }
            return new SigninResponseDTO { Success = res.IsSuccessStatusCode };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace MissTortas.Desktop.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public async Task<string?> SignInAsync(SigninRequest signInDTO)
        {
            var client = MissTortasHttpClient.Instance.Client;
            var res = await client.PostAsJsonAsync("auth/signin", signInDTO);
            if(res.IsSuccessStatusCode)
            {
                var response = await res.Content.ReadFromJsonAsync<SigninResponse>();
                MissTortasToken.AccessToken = response?.AccessToken;
                return response?.AccessToken;
            }
            return null;
        }

        public async Task<bool> SignUpAsync(SignupRequest signUpDTO)
        {
            var client = MissTortasHttpClient.Instance.Client;
            var res = await client.PostAsJsonAsync("auth/signup", signUpDTO);
            return res.IsSuccessStatusCode;
        }
    }
}

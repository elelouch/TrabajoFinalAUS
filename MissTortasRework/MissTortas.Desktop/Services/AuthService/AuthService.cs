using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public async Task<bool> SignIn(SignInDTO signInDTO)
        {
            var res = await MissTortasHttpClient.Instance.Client.PostAsJsonAsync("auth/signin", signInDTO);
            return res.IsSuccessStatusCode;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.AuthService
{
    public interface IAuthService
    {
        public Task<string?> SignInAsync(SigninRequest signInDTO);
        public Task<bool> SignUpAsync(SignupRequest signUpDTO);
    }
}

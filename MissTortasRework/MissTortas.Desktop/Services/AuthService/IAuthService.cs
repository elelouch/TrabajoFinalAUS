using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.AuthService
{
    public interface IAuthService
    {
        public Task<bool> SignIn(SignInDTO signInDTO);
    }
}

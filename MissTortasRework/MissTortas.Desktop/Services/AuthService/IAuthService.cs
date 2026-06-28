using MissTortas.Desktop.Services.DTO;

namespace MissTortas.Desktop.Services.AuthService
{
    public interface IAuthService
    {
        public Task SignInAsync(SigninRequest signInDTO);
        public Task<string?> SignUpAsync(SignupRequest signUpDTO);
        public Task<UserMetadata?> GetUserMetadataAsync(SignupRequest signUpDTO);
    }
}

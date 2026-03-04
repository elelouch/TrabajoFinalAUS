using Microsoft.AspNetCore.Identity;

namespace MissTortas.Services.DTO.Security
{
    public class SignUpUserResultDTO
    {
        public IdentityResult? IdentityResult { get; set; }
        public IEnumerable<IdentityError> Errors { get; set; } = [];
    }
}

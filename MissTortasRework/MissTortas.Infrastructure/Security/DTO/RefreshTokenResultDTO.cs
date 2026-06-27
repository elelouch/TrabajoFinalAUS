using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Infrastructure.Security.DTO
{
    public class RefreshTokenResultDTO
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public string ExpiresIn { get; set; } = string.Empty;
    }
}

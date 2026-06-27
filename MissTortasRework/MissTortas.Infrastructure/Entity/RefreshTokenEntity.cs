using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Infrastructure.Entity
{
    public class RefreshTokenEntity
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public string? UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsRevoked { get; set; }
    }
}

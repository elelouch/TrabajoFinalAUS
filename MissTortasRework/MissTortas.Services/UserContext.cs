using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Services
{
    public class UserContext
    {
        public bool IsAuthenticated { get; init; }
        public long UserId { get; init; }
        public string AppUserId { get; init; } = "";
        public string Username { get; init; } = "";
        public IReadOnlyList<string> Roles { get; init; } = [];
        public long[] RelatedSubjectId { get; init; } = [];
        public IEnumerable<string> Permissions { get; set; } = [];
    }
}

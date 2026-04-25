using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services
{
    public class UserContext
    {
        public bool IsAuthenticated { get; init; }
        public long UserId { get; init; }
        public IReadOnlyList<string> Roles { get; init; } = [];
        public long DefaultSubjectId { get; init; }
    }
}

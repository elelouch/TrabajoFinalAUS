using MissTortas.Data.Entity.Security.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface ITokenGenerator
    {
        public Task<string> GenerateToken(ApplicationUser user);
    }
}

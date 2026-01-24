using MissTortas.Data.Entity.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface ITokenGenerator
    {
        public string GenerateToken(ApplicationUser user);
    }
}

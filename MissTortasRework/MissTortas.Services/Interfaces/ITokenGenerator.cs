using MissTortas.Data.Entity.Security.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Mapper
{
    public interface ITokenGenerator
    {
        public string GenerateToken(ApplicationUser user);
    }
}

using MissTortas.Infrastructure.DTO.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MissTortas.Infrastructure.Mappings.Interfaces
{
    public interface IUserMapper
    {
        public UserMetadata ClaimsPrincipalToUserMetadata(ClaimsPrincipal principal);
    }
}

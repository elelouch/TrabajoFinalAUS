using MissTortas.Services.DTO.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface IUserService
    {
        public Task<long> CreateUserAsync(CreateUserDTO createUserDTO);
    }
}

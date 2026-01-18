using MissTortas.Models.Security.User;
using MissTortas.Services.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserBase> RegisterUserAsync(UserRegistrationDTO dto);
        public void DeleteUser(long id);
        public Task<UserBase> LoginUser(UserLoginDTO dto);
        public Task<UserBase> FindUser(long id);
    }
}

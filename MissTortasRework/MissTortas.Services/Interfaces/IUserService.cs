using MissTortas.Data.Entity.Security;
using MissTortas.Services.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> RegisterUserAsync(UserRegistrationDTO dto);
        public void DeleteUser(long id);
        public Task<User> LoginUserAsync(UserLoginDTO dto);
        public Task<User> FindUserAsync(long id);
        public Task<List<User>> AllUserAsync();
    }
}

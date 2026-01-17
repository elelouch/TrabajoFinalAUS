using MissTortas.Models.Security.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Models.Interfaces
{
    public interface IUserRepository: IRepositoryCrud<UserBase>
    {
        public Task<UserBase> CreateUser(UserBase user);
        public Task<UserBase?> FindByUsernameOrEmailAsync(string username, string email);
    }
}

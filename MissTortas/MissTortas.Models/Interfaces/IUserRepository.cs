using MissTortas.Models.Model.Security.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Models.Interfaces
{
    public interface IUserRepository: IRepositoryCrud<UserBase>
    {
        public Task CreateUser(UserBase user);
    }
}

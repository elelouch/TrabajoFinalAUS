using MissTortasEngine.Model.Security.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface IUserService
    {
        public Task RegisterUser(UserRegistrationDTO dto);
        public void DeleteUser(long id);
    }
}

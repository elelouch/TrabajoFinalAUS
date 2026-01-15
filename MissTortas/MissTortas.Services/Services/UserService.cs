using System;
using System.Collections.Generic;
using System.Text;
using MissTortas.Models.Model.Security.User;
using MissTortas.Models.Interfaces;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using MissTortasEngine.Model.Security.User;
using System.Text.RegularExpressions;

namespace MissTortas.Services.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async void DeleteUser(long id)
        {
            var user = await userRepository.FindAsync(id) ?? throw new EntityNotFoundException($"The user {id} has not been found");
            userRepository.Delete(user);
            await userRepository.SaveChangesAsync();
        }

        public async Task RegisterUser(UserRegistrationDTO dto)
        {
            var newUser = new UserBase { UserName = dto.Username, Email = dto.Email, Password = dto.Password };
            string passwordRegex = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$";
            Regex.Match(newUser.Password, passwordRegex);
            await userRepository.CreateUser(newUser);
            await userRepository.SaveChangesAsync();

        }
    }
}

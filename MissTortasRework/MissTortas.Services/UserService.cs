using System;
using System.Collections.Generic;
using System.Text;
using MissTortas.Models.Interfaces;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using System.Text.RegularExpressions;
using MissTortas.Services.DTO.User;
using Microsoft.AspNetCore.Identity;
using MissTortas.Models.Security.User;

namespace MissTortas.Services
{
    public class UserService(IUserRepository userRepository) : Interfaces.IUserService
    {
        public async void DeleteUser(long id)
        {
            var user = await userRepository.FindAsync(id) ?? throw new EntityNotFoundException($"The user {id} has not been found");
            userRepository.Delete(user);
            await userRepository.SaveChangesAsync();
        }

        public async Task<UserBase> RegisterUserAsync(UserRegistrationDTO dto)
        {
            if (dto == null)
            {
                throw new EntityNotFoundException("DTO shouldn't be null");
            }
            var newUser = new UserBase { UserName = dto.Username, Email = dto.Email, Password = dto.Password };
            var user = await userRepository.FindByUsernameOrEmailAsync(dto.Username, dto.Email);
            if(user != null)
            {
                throw new UserAlreadyCreatedException("User already created");
            }
            await userRepository.CreateUser(newUser);
            await userRepository.SaveChangesAsync();
            return newUser;
        }

        public async Task<UserBase> LoginUser(UserLoginDTO dto)
        {
            if (dto == null)
            {
                throw new EntityNotFoundException("DTO shouldn't be null");
            }
            var user = await userRepository.FindByUsernameOrEmailAsync(dto.Username, dto.Username) ?? throw new EntityNotFoundException("User not found");
            var passwordHasher = new PasswordHasher<UserBase>();
            var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, dto.Password);
            if (verificationResult == PasswordVerificationResult.Failed)
            {
                throw new PasswordException("Password is not correct");
            }
            return user;
        }

        public async Task<UserBase> FindUser(long id)
        {
            return (await userRepository.FindAsync(id) ?? throw new EntityNotFoundException("User not found"));
        }
    }
}

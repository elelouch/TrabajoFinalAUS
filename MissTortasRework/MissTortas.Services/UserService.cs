using System;
using System.Collections.Generic;
using System.Text;
using MissTortas.Data.Interfaces;
using MissTortas.Services.Exceptions;
using MissTortas.Services.Interfaces;
using System.Text.RegularExpressions;
using MissTortas.Services.DTO.User;
using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Security;

namespace MissTortas.Services
{
    public class UserService(UserManager<User> userManager, SignInManager<User> signInManager) : IUserService
    {
        public async void DeleteUser(long id)
        {
            var user = await userManager.FindByIdAsync(id.ToString()) ?? throw EntityNotFoundException("User doesn't exist");
            await (userManager.DeleteAsync(user));
        }

        public async Task<User> RegisterUserAsync(UserRegistrationDTO dto)
        {
            if (dto == null)
            {
                throw new EntityNotFoundException("DTO shouldn't be null");
            }
            var newUser = new User { UserName = dto.Username, Email = dto.Email };
            var user = await userRepository.FindByUsernameOrEmailAsync(dto.Username, dto.Email);
            if(user != null)
            {
                throw new UserAlreadyCreatedException("User already created");
            }
            var passwordHasher = new PasswordHasher<User>();
            newUser.PasswordHash = passwordHasher.HashPassword(newUser, dto.Password);
            await userRepository.InsertAsync(newUser);
            await userRepository.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> LoginUserAsync(UserLoginDTO dto)
        {
            if (dto == null)
            {
                throw new EntityNotFoundException("DTO shouldn't be null");
            }
            var user = await userRepository.FindByUsernameOrEmailAsync(dto.Username, dto.Username) ?? throw new EntityNotFoundException("User not found");
            var result = await signInManager.PasswordSignInAsync(user, dto.Password, false, true);
            if (result.Succeeded)
            {
                throw new PasswordException("Password is not correct");
            }
            return user;
        }

        public async Task<User> FindUserAsync(long id)
        {
            return (await userRepository.FindAsync(id) ?? throw new EntityNotFoundException("User not found"));
        }

        public async Task<List<User>> AllUserAsync()
        {
            return (await userRepository.FindAllAsync());
        }
    }
}

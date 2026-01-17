using Microsoft.EntityFrameworkCore;
using MissTortas.Models.Context;
using MissTortas.Models.Repositories;
using MissTortas.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using MissTortas.Models.Security.User;

namespace MissTortas.Models.Repositories
{
    public class UserRepository(MissTortasContext context) : RepositoryCrud<UserBase>(context), IUserRepository
    {
        public async Task<UserBase> CreateUser(UserBase user)
        {
            var passwordHasher = new PasswordHasher<UserBase>();
            var hashedPassword = passwordHasher.HashPassword(user, user.Password);
            user.PasswordHash = hashedPassword;
            await this.InsertAsync(user);
            return user;
        }

        public async Task<UserBase?> FindByUsernameOrEmailAsync(string username, string email)
        {
            return context.Users.Where(user => user.UserName == username || user.Email == email).FirstOrDefault();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MissTortas.Models.Context;
using MissTortas.Models.Repositories;
using MissTortas.Models.Interfaces;
using MissTortas.Models.Model.Security.User;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace MissTortas.Models.Repositories
{
    public class UserRepository(DbContext context) : RepositoryCrud<UserBase>(context), IUserRepository
    {
        public async Task CreateUser(UserBase user)
        {
            var passwordHasher = new PasswordHasher<UserBase>();
            var hashedPassword = passwordHasher.HashPassword(user, user.Password);
            user.PasswordHash = hashedPassword;
            await this.InsertAsync(user);
        }
    }
}

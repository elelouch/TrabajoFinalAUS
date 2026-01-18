using Microsoft.EntityFrameworkCore;
using MissTortas.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using MissTortas.Data.Entity.Security;
using MissTortas.Data.Interfaces;
using MissTortas.Data.Context;

namespace MissTortas.Data.Repositories
{
    public class UserRepository(MissTortasContext context) : RepositoryCrud<User>(context), IUserRepository
    {
        public async Task<User?> FindByUsernameOrEmailAsync(string username, string email)
        {
            return context.Users.Where(user => user.UserName == username || user.Email == email).FirstOrDefault();
        }
    }
}

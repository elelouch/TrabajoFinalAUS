using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MissTortas.Data.Context;
using MissTortas.Data.Entity.Security;
using MissTortas.Data.Interfaces;
using MissTortas.Data.Repositories;
using MissTortas.Engine;
using MissTortas.Services;
using MissTortas.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddMissTortasServiceCore(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<SignInManager<ApplicationUser>>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserStore<ApplicationUser>, UserStore<ApplicationUser, ApplicationRole, MissTortasContext, long>>();
            services.AddScoped<UserManager<ApplicationUser>>();
            return services;
        }
    }
}

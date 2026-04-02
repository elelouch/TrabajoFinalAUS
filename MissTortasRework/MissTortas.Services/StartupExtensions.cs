using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MissTortas.Infrastructure.Context;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Repositories;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Repository;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapper;
using MissTortas.Services.Mapper.Interfaces;
using MissTortas.Services.Security.Handlers;
using MissTortas.Services.Security.Requirements;

namespace MissTortas.Services
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddMissTortasServiceCore(this IServiceCollection services)
        {            
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentMapper, PaymentMapper>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductMapper, ProductMapper>();
            services.AddScoped<IOrderMapper, OrderMapper>();
            services.AddScoped<IRoleMapper, RoleMapper>();

            services.AddScoped<IAuthorizationHandler, UpdateUserHandler>();
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();

            return services;
        }
    }
}

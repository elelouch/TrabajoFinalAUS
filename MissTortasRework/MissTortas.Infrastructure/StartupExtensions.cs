using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MissTortas.Infrastructure.Context;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Repositories;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Repository;

namespace MissTortas.Infrastructure
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddMissTortasInfrastructure(
            this IServiceCollection services,
            IConfigurationRoot configuration
            )
        {
            var connectionString = configuration.GetConnectionString("MissTortasContext") ?? throw new InvalidOperationException("Connection string not found");
            services.AddDbContext<MissTortasContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<MissTortasContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<ISimpleStorageRepository, SimpleStorageRepository>();
            services.AddScoped<ISimpleStorage, SimpleStorage>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
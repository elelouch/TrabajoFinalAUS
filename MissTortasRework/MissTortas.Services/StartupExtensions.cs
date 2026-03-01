using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MissTortas.Data.Context;
using MissTortas.Data.Entity.Security.User;
using MissTortas.Data.Interfaces;
using MissTortas.Data.Repositories;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapper;

namespace MissTortas.Services
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddMissTortasServiceCore(this IServiceCollection services, IConfigurationRoot configuration)
        {
            var connectionString = configuration.GetConnectionString("MissTortasContext") ?? throw new InvalidOperationException("Connection string not found");
            services.AddDbContext<MissTortasContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentMapper, PaymentMapper>();
            services.AddScoped<ISimpleStorageRepository, SimpleStorageRepository>();
            services.AddScoped<ISimpleStorage, SimpleStorage>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<SignInManager<ApplicationUser>>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IUserStore<ApplicationUser>, UserStore<ApplicationUser, ApplicationRole, MissTortasContext, long>>();
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<IProductMapper, ProductMapper>();
            services.AddScoped<IOrderMapper, OrderMapper>();
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<MissTortasContext>()
                .AddDefaultTokenProviders();
            return services;
        }
    }
}

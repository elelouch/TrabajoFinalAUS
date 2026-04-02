using Microsoft.Extensions.DependencyInjection;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapper;
using MissTortas.Services.Mapper.Interfaces;

namespace MissTortas.Services
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddMissTortasServiceCore(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentMapper, PaymentMapper>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductMapper, ProductMapper>();
            services.AddScoped<IOrderMapper, OrderMapper>();
            services.AddScoped<IRoleMapper, RoleMapper>();


            return services;
        }
    }
}

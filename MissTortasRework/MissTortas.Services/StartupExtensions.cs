using Microsoft.Extensions.DependencyInjection;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Mapping;
using MissTortas.Services.Mapping.Interfaces;

namespace MissTortas.Services
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddMissTortasServices(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentMapper, PaymentMapper>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductMapper, ProductMapper>();
            services.AddScoped<IOrderMapper, OrderMapper>();
            return services;
        }
    }
}

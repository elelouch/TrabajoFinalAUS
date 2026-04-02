using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MissTortas.Infrastructure.Configuration;
using MissTortas.Infrastructure.Context;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Repositories;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Permissions;
using MissTortas.Repository;
using MissTortas.Services.Interfaces;
using MissTortas.Services.Security.Constants;
using MissTortas.Services.Security.Handlers;

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

            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<ISimpleStorageRepository, SimpleStorageRepository>();
            services.AddScoped<ISimpleStorage, SimpleStorage>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAuthorizationHandler, UpdateUserHandler>();
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
            });

            var requireAuthPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                 .Build();

            services.AddAuthorizationBuilder().SetFallbackPolicy(requireAuthPolicy);

            var jwtOptions = configuration.GetSection("Jwt").Get<JwtOptions>();
            services.AddAuthorization();
            services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey("VerySecureSymmetricKeySaracatungueanos"u8.ToArray()),
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidateAudience = true,
                        ValidateIssuer = true
                    };
                });

            services.AddAuthorizationBuilder()
                .AddPolicy(PolicyName.ReadUsers, policy => policy.AddRequirements(PermissionConstants.ReadUsers))
                .AddPolicy(PolicyName.UpdateUsers, policy => policy.AddRequirements(PermissionConstants.UpdateUsers))
                .AddPolicy(PolicyName.ReadPermissions, policy => policy.RequireClaim(Permission.ClaimName, Permission.ReadPermissions.Code))
                .AddPolicy(PolicyName.AssignPermissions, policy => policy.RequireClaim(Permission.ClaimName, Permission.AssignPermissions.Code))
                .AddPolicy(PolicyName.ReadRoles, policy => policy.RequireClaim(Permission.ClaimName, Permission.ReadRoles.Code))
                .AddPolicy(PolicyName.ManageOrders, policy => policy.RequireClaim(Permission.ClaimName, Permission.ManageOrders.Code))
                .AddPolicy(PolicyName.PlaceOrders, policy => policy.RequireClaim(Permission.ClaimName, Permission.PlaceOrders.Code))
             ;
            return services;
        }
    }
}
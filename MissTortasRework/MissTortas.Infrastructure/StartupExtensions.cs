using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MissTortas.Infrastructure.Configuration;
using MissTortas.Infrastructure.Context;
using MissTortas.Infrastructure.Interfaces;
using MissTortas.Infrastructure.Mappings;
using MissTortas.Infrastructure.Mappings.Interfaces;
using MissTortas.Infrastructure.Repositories;
using MissTortas.Infrastructure.Security;
using MissTortas.Infrastructure.Security.Constants;
using MissTortas.Infrastructure.Security.Handlers;
using MissTortas.Infrastructure.Security.Identity;
using MissTortas.Infrastructure.Security.Interface;
using MissTortas.Infrastructure.Security.Permissions;
using MissTortas.Infrastructure.Security.Requirements;
using MissTortas.Services.Repositories;
using System.Security.Claims;
using System.Text;

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
            services.AddDbContext<MissTortasContext>(options => options.UseSqlite(connectionString));
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<MissTortasContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<ISimpleStorageRepository, SimpleStorageRepository>();
            services.AddScoped<ISimpleStorage, SimpleStorage>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAuthorizationHandler, UpdateUserHandler>();
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();
            services.AddScoped<IAuthorizationHandler, ManagePreparationHandler>();
            services.AddScoped<IAuthorizationHandler, ManageAssignedPreparationHandler>();
            services.AddScoped<IAuthorizationHandler, OrderHandler>();
            services.AddScoped<IRoleMapper, RoleMapper>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserMapper, UserMapper>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
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

            var jwtOptions = configuration.GetSection("Jwt").Get<JwtOptions>() ?? throw new InvalidOperationException("Jwt options not found in appsettings");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var token = context.Request.Cookies["X-Access-Token"];

                            if (string.IsNullOrEmpty(token))
                            {
                                var authHeader = context.Request.Headers.Authorization.ToString();
                                if (authHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                                {
                                    token = authHeader["Bearer ".Length..];
                                }
                            }

                            if (!string.IsNullOrEmpty(token))
                            {
                                context.Token = token;
                            }

                            return Task.CompletedTask;
                        },
                    };

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions!.Key)),
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidateAudience = true,
                        ValidateIssuer = true
                    };
                });


            services.AddAuthorizationBuilder()
                .SetFallbackPolicy(requireAuthPolicy)
                .AddPolicy(PolicyName.ReadUsers, policy => policy.AddRequirements(PermissionConstants.ReadUsers))
                .AddPolicy(PolicyName.UpdateUsers, policy => policy.AddRequirements(PermissionConstants.UpdateUsers))
                .AddPolicy(PolicyName.ReadPermissions, policy => policy.RequireClaim(Permission.ClaimName, Permission.ReadPermissions.Code))
                .AddPolicy(PolicyName.AssignPermissions, policy => policy.RequireClaim(Permission.ClaimName, Permission.AssignPermissions.Code))
                .AddPolicy(PolicyName.ReadRoles, policy => policy.RequireClaim(Permission.ClaimName, Permission.ReadRoles.Code))
                .AddPolicy(PolicyName.ManageOrders, policy => policy.RequireClaim(Permission.ClaimName, Permission.ManageOrders.Code))
                .AddPolicy(PolicyName.ManageProducts, policy => policy.RequireClaim(Permission.ClaimName, Permission.ManageProducts.Code))
                .AddPolicy(PolicyName.PlaceOrders, policy => policy.RequireClaim(Permission.ClaimName, Permission.PlaceOrders.Code))
                .AddPolicy(PolicyName.ManageAssignedPreparations, policy => policy.AddRequirements(new ManageAssignedPreparationRequirement()))
             ;
            return services;
        }
    }
}
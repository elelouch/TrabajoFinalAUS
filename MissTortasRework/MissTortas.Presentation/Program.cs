using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using MissTortas.Presentation.DTO;
using MissTortas.Presentation;
using MissTortas.Services;
using MissTortas.Services.Mapper;
using MissTortas.Services.Interfaces;
using Microsoft.Extensions.FileProviders;
using MissTortas.Services.Security.Constants;
using MissTortas.Presentation.Validators.Orders;
using MissTortas.Presentation.Validators.Products;
using MissTortas.Presentation.DTO.Orders;
using MissTortas.Presentation.DTO.Products;
using MissTortas.Data.Entity.Security.User;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// DI
builder.Services.AddScoped<IValidator<UpdateProduct>, UpdateProductDTOValidator>();
builder.Services.AddScoped<IValidator<CreateProductCategory>, CreateProductCategoryDTOValidator>();
builder.Services.AddScoped<IValidator<CreateProduct>, CreateProductDTOValidator>();
builder.Services.AddScoped<IValidator<CreateSaleProduct>, CreateSaleProductDTOValidator>();
builder.Services.AddScoped<IValidator<CreateOrder>, CreateOrderDTOValidator>();
builder.Services.AddScoped<IValidator<CreateOrderType>, CreateOrderTypeDTOValidator>();
builder.Services.AddScoped<IValidator<PlaceOrder>, PlaceOrderDTOValidator>();

builder.Services.AddScoped<IProductsDTOValidator, ProductsDTOValidator>();
builder.Services.AddScoped<IOrdersDTOValidator, OrdersDTOValidator>();


builder.Services.AddMissTortasServiceCore(builder.Configuration);

builder.Services.Configure<IdentityOptions>(options =>
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

builder.Services.AddAuthorizationBuilder().SetFallbackPolicy(requireAuthPolicy);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication()
    .AddJwtBearer(jwtOptions =>
    {
        jwtOptions.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey("VerySecureSymmetricKeySaracatungueanos"u8.ToArray()),
            ValidIssuer = "https://localhost",
            ValidAudience = "https://localhost",
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidateAudience = true,
            ValidateIssuer = true
        };
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("bearer", document)] = []
    });
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Users.ViewAll", policy => policy.AddRequirements(PermissionRequirementConstants.ViewAllUserPermission))
    .AddPolicy("Users.UpdateAll", policy => policy.AddRequirements(PermissionRequirementConstants.ViewAllUserPermission))
    .AddPolicy("Roles.AssignClaim", policy => policy.AddRequirements(PermissionRequirementConstants.ViewAllUserPermission))
    .AddPolicy("Claims.ViewAll", policy => policy.AddRequirements(PermissionRequirementConstants.ViewAllClaims));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
    app.MapStaticAssets();
    var fileOptions = new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
        RequestPath = "/uploads"
    };
    app.UseStaticFiles(fileOptions);
}

app.UseAuthentication();

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>)) as UserManager<ApplicationUser>;
    var roleManager = scope.ServiceProvider.GetService(typeof(RoleManager<ApplicationRole>)) as RoleManager<ApplicationRole>;
    ApplicationDbInitializer.SeedDatabase(userManager!, roleManager!);
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
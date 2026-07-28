using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi;
using MissTortas.Infrastructure;
using MissTortas.Infrastructure.Configuration;
using MissTortas.Infrastructure.Context;
using MissTortas.Services;
using MissTortas.View.DTO.Orders;
using MissTortas.View.DTO.Products;
using MissTortas.View.DTO.Security;
using MissTortas.View.Errors.Handlers;
using MissTortas.View.Mappers;
using MissTortas.View.Validators.Orders;
using MissTortas.View.Validators.Products;
using MissTortas.View.Validators.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "MissTortas API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT access token (no need to type 'Bearer ' prefix)."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

// DI

builder.Services.AddScoped<IValidator<ModifyApplicationRole>, AssignPermissionToRoleValidator>();
builder.Services.AddScoped<IValidator<UpdateProductRequest>, UpdateProductValidator>();
builder.Services.AddScoped<IValidator<CreateProductCategoryRequest>, CreateProductCategoryValidator>();
builder.Services.AddScoped<IValidator<CreateProductRequest>, CreateProductValidator>();
builder.Services.AddScoped<IValidator<CreateSaleProductRequest>, CreateSaleProductValidator>();
builder.Services.AddScoped<IValidator<CreateOrderRequest>, CreateOrderDTOValidator>();
builder.Services.AddScoped<IValidator<CreateOrderTypeRequest>, CreateOrderTypeDTOValidator>();
builder.Services.AddScoped<IValidator<PlaceOrderRequest>, PlaceOrderDTOValidator>();
builder.Services.AddScoped<IValidator<UserModification>, UserModificationValidator>();
builder.Services.AddScoped<IValidator<MissTortasRegisterRequest>, MissTortasRegisterRequestValidator>();
builder.Services.AddScoped<IValidator<CreateRoleRequest>, CreateRoleRequestValidator>();

builder.Services.AddScoped<IPresentationOrderMapper, PresentationOrderMapper>();
builder.Services.AddScoped<IUserMapper, UserMapper>();
builder.Services.AddScoped<IPresentationProductMapper, PresentationProductMapper>();

builder.Services.AddMissTortasInfrastructure(builder.Configuration);
builder.Services.AddMissTortasServices();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };

    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = 403;
        return Task.CompletedTask;
    };
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapStaticAssets();
    var fileOptions = new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
        RequestPath = "/uploads"
    };
    app.UseStaticFiles(fileOptions);
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    await ApplicationDbInitializer.SeedDatabaseAsync(scope.ServiceProvider);
}


app.UseAuthentication();

app.UseAuthorization();

app.UseStatusCodePages();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

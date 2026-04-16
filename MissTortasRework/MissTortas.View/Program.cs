using FluentValidation;
using Microsoft.Extensions.FileProviders;
using MissTortas.Infrastructure;
using MissTortas.Infrastructure.Configuration;
using MissTortas.Services;
using MissTortas.Services.Mapping;
using MissTortas.Services.Mapping.Interfaces;
using MissTortas.View.DTO.Orders;
using MissTortas.View.DTO.Products;
using MissTortas.View.DTO.Security;
using MissTortas.View.Mappers;
using MissTortas.View.Validators.Orders;
using MissTortas.View.Validators.Products;
using MissTortas.View.Validators.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
// error handling
builder.Services.AddProblemDetails();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

// DI

builder.Services.AddScoped<IValidator<AssignPermissionToRole>, AssignPermissionToRoleValidator>();
builder.Services.AddScoped<IValidator<UpdateProduct>, UpdateProductDTOValidator>();
builder.Services.AddScoped<IValidator<CreateProductCategory>, CreateProductCategoryDTOValidator>();
builder.Services.AddScoped<IValidator<CreateProduct>, CreateProductDTOValidator>();
builder.Services.AddScoped<IValidator<CreateSaleProduct>, CreateSaleProductDTOValidator>();
builder.Services.AddScoped<IValidator<CreateOrder>, CreateOrderDTOValidator>();
builder.Services.AddScoped<IValidator<CreateOrderType>, CreateOrderTypeDTOValidator>();
builder.Services.AddScoped<IValidator<PlaceOrder>, PlaceOrderDTOValidator>();
builder.Services.AddScoped<IValidator<UserModification>, UserModificationValidator>();


builder.Services.AddScoped<IOrderMapper, OrderMapper>();
builder.Services.AddScoped<IUserMapper, UserMapper>();

builder.Services.AddMissTortasInfrastructure(builder.Configuration);
builder.Services.AddMissTortasServices();

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
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
}

using (var scope = app.Services.CreateScope())
{
    await ApplicationDbInitializer.SeedDatabaseAsync(scope.ServiceProvider);
}

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

//app.UseStatusCodePages();

//app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

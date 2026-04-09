using FluentValidation;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi;
using MissTortas.Infrastructure;
using MissTortas.Infrastructure.Configuration;
using MissTortas.Presentation.DTO.Orders;
using MissTortas.Presentation.DTO.Products;
using MissTortas.Presentation.DTO.Security;
using MissTortas.Presentation.Mappers;
using MissTortas.Presentation.Validators.Orders;
using MissTortas.Presentation.Validators.Products;
using MissTortas.Presentation.Validators.Security;
using MissTortas.Services;
using MissTortas.Services.Mapping;
using MissTortas.Services.Mapping.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
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


builder.Services.AddScoped<ISecurityDTOValidator, SecurityDTOValidator>();

builder.Services.AddScoped<IOrderMapper, OrderMapper>();
builder.Services.AddScoped<IUserMapper, UserMapper>();

builder.Services.AddMissTortasServices();
builder.Services.AddMissTortasInfrastructure(builder.Configuration);

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
    app.UseDeveloperExceptionPage();

}

app.UseAuthentication();

app.UseAuthorization();

app.UseStatusCodePages();

app.UseExceptionHandler();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await ApplicationDbInitializer.SeedDatabase(services);
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
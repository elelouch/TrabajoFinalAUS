using Microsoft.EntityFrameworkCore;
using MissTortas.Data.Context;
using MissTortas.Data.Interfaces;
using MissTortas.Data.Repositories;
using MissTortas.Engine.DTO;
using MissTortas.Engine.Validators;
using MissTortas.Services;
using MissTortas.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var connectionString = builder.Configuration.GetConnectionString("MissTortasContext") ?? throw new InvalidOperationException("Connection string not found");
builder.Services.AddDbContext<MissTortasContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IValidator<CreateUserDTO>, CreateUserValidator>();

//var requireAuthPolicy = new AuthorizationPolicyBuilder()
//    .RequireAuthenticatedUser()
//    .Build();
//builder.Services.AddAuthorizationBuilder().SetFallbackPolicy(requireAuthPolicy);
//builder.Services.AddAuthentication()
//    .AddJwtBearer("some-scheme", jwtOptions =>
//    {

//    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
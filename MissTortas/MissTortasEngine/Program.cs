using Microsoft.EntityFrameworkCore;
using MissTortas.Models.Context;
using MissTortas.Models.Interfaces;
using MissTortas.Models.Repositories;
using MissTortas.Services;
using MissTortas.Services.Interfaces;
// using MissTortasEngine.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<MissTortasContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("MissTortasContext") ?? throw new InvalidOperationException("Connection string 'MvcMovieContext' not found."))
    );
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<MissTortasContext>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MissTortasContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(opt =>
    {
        opt.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
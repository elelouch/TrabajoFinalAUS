using Microsoft.EntityFrameworkCore;
using MissTortasEngine.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<EngineContext>(opt => opt.UseInMemoryDatabase("MissTortasEngine"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

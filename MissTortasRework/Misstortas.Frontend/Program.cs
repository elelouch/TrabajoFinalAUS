using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using Misstortas.Frontend;
using Misstortas.Frontend.Components;
using Misstortas.Frontend.Services.Auth;
using Misstortas.Frontend.Services.Files;
using Misstortas.Frontend.Services.Order;
using Misstortas.Frontend.Services.Products;
using Misstortas.Frontend.Services.Shared;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var apiHostsOptions = builder.Configuration.GetSection("APIHostsOptions");

builder.Services.Configure<APIHostsOptions>(builder.Configuration.GetSection("APIHostsOptions"));

var apiConfig = apiHostsOptions.Get<APIHostsOptions>();

builder.Services.AddHttpClient<IMissTortasClient, MissTortasClient>(options =>
{
    options.BaseAddress = apiConfig!.APIBaseEndpoint;
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<ISaleProductCartService, SaleProductCartService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IFileUrlBuilder, FileUrlBuilder>();
builder.Services.AddScoped<IToastService, ToastService>();

var jwtOptions = builder.Configuration
    .GetSection("JwtOptions")
    .Get<JwtOptions>();

builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
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

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["X-Access-Token"];
                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

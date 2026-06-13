using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Misstortas.Frontend;
using Misstortas.Frontend.Components;
using Misstortas.Frontend.Services.Auth;
using Misstortas.Frontend.Services.Files;
using Misstortas.Frontend.Services.Products;
using Misstortas.Frontend.Services.Shared;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var sape = builder.Configuration.GetSection("APIHostsOptions");

builder.Services.Configure<APIHostsOptions>(builder.Configuration.GetSection("APIHostsOptions"));

var apiConfig = sape.Get<APIHostsOptions>();

builder.Services.AddHttpClient<IAuthClient, AuthClient>("Auth.Client", httpClient =>
{
    httpClient.BaseAddress = apiConfig!.APIBaseEndpoint;
});

builder.Services.AddHttpClient<IProductsClient, ProductsClient>("Products.Client", httpClient =>
{
    httpClient.BaseAddress = apiConfig!.APIBaseEndpoint;
});

builder.Services.AddScoped<ISaleProductCartService, SaleProductCartService>();
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
            IssuerSigningKey =
        new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtOptions!.Key)),

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

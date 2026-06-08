using Misstortas.Frontend;
using Misstortas.Frontend.Components;
using Misstortas.Frontend.Services.Auth;
using Misstortas.Frontend.Services.Files;
using Misstortas.Frontend.Services.Products;

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

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

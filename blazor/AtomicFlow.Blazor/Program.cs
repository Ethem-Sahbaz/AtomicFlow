using AtomicFlow.Blazor;
using AtomicFlow.Blazor.Client.Services;
using AtomicFlow.Blazor.Components;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Yarp.ReverseProxy.Transforms;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddAuthenticationStateSerialization(options => options.SerializeAllClaims = true);

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"]!;
    options.ClientId = builder.Configuration["Auth0:ClientId"]!;
    options.ClientSecret = builder.Configuration["Auth0:ClientSecret"]!;
})
.WithAccessToken(accessTokenOptions =>
{
    accessTokenOptions.Audience = builder.Configuration["Auth0:Audience"]!;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpForwarder();
builder.Services.AddTransient<ForwarderServerHttpHandler>();
builder.Services.AddScoped<IHabitService, HabitsService>();

builder.Services.AddHttpClient(nameof(HabitsService), config =>
{
    config.BaseAddress = new Uri("https://localhost:7141");
}).ConfigurePrimaryHttpMessageHandler<ForwarderServerHttpHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(AtomicFlow.Blazor.Client._Imports).Assembly);

app.MapGet("account/login", async (HttpContext context, string returnUrl = "/") =>
{
    AuthenticationProperties loginProperties = new LoginAuthenticationPropertiesBuilder()
        .WithRedirectUri(returnUrl)
        .Build();

    await context.ChallengeAsync(Auth0Constants.AuthenticationScheme, loginProperties);
});

app.MapGet("account/logout", async context =>
{
    AuthenticationProperties logoutProperties = new LogoutAuthenticationPropertiesBuilder()
        .WithRedirectUri("/")
        .Build();

    await context.SignOutAsync(Auth0Constants.AuthenticationScheme, logoutProperties);
    // Deletes the auth cookie that asp.net uses to check if user is logged in.
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, logoutProperties);
});

// Get destination url from appsettings.
app.MapForwarder("/{**endpoint}", builder.Configuration["API:Url"]!, transformBuilder =>
{
    transformBuilder.AddRequestTransform(async requestTransformContext =>
    {
        string? token = await requestTransformContext.HttpContext.GetTokenAsync("access_token");
        // Use ProxyRequest for adding the access token to the header.
        requestTransformContext.ProxyRequest.Headers.Authorization = new("Bearer", token);
    });
})
.RequireAuthorization();

app.Run();

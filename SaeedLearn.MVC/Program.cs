using Microsoft.Extensions.Configuration;
using SaeedLearn.Application;
using SaeedLearn.Application.Contracts.Identity;
using SaeedLearn.Identity;
using SaeedLearn.Identity.Services;
using SaeedLearn.Persistence;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ConfigureApplicationService();
builder.Services.ConfigurePersistenceServices(configuration);
builder.Services.ConfigureIdentityServices(configuration);

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddTransient<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "login",
    pattern: "Account/Login/{returnUrl?}",
    defaults: new
    {
        controller = "Account",
        action = "Login"
    });
app.Run();
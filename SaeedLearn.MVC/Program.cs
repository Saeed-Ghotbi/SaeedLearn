using Microsoft.Extensions.Configuration;
using SaeedLearn.Application;
using SaeedLearn.Application.Contracts.Identity;
using SaeedLearn.Identity;
using SaeedLearn.Identity.Services;
using SaeedLearn.MVC.Contracts;
using SaeedLearn.MVC.Services;
using SaeedLearn.MVC.Services.Base;
using SaeedLearn.Persistence;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ConfigureApplicationService();
builder.Services.ConfigurePersistenceServices(configuration);
builder.Services.ConfigureIdentityServices(configuration);
builder.Services.AddHttpClient<IClient, Client>(cl => cl.BaseAddress = new Uri("http://localhost:5229"));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddRazorPages();

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddScoped<ICourseService, CourseService>();

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

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
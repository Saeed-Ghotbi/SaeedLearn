using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using SaeedLearn.Identity.Configurations;
using SaeedLearn.Identity.Models;

namespace SaeedLearn.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<SaeedLearnIdentityDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("SaeedLearnIdentityConnectionString"),
                    
                    b=> b.MigrationsAssembly(typeof(SaeedLearnIdentityDbContext).Assembly.FullName));
            });

            services.AddIdentity<User, IdentityRole>(
                options =>
                {
                    // Default Password settings.
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;
                })
                .AddEntityFrameworkStores<SaeedLearnIdentityDbContext>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/login";
                    options.LogoutPath = "/Account/logout";
                    options.Cookie.Name = "SaeedLearn.auth";
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromHours(24);
                });


            return services;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaeedLearn.Identity.Models;

namespace SaeedLearn.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();
            builder.HasData(
                new User
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    Firstname = "Saeed",
                    Lastname = "Ghotbi",
                    Email = "admin@SaeedLearn.com",
                    NormalizedEmail = "ADMIN@SAEEDlEARN.COM",
                    EmailConfirmed = true,
                    IsAdmin = true,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PhoneNumber = "09380883666",
                    PhoneNumberConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Password@123")
                }
            );
        }
    }
}

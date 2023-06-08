using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaeedLearn.Identity.Configurations;
using SaeedLearn.Identity.Models;

namespace SaeedLearn.Identity
{
    public class SaeedLearnIdentityDbContext : IdentityDbContext<User>
    {
        public SaeedLearnIdentityDbContext(DbContextOptions<SaeedLearnIdentityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());

        }
    }
}

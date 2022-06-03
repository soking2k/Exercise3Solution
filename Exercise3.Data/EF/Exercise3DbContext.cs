using Exercise3.Data.Configurations;
using Exercise3.Data.Entities;
using Exercise3.Data.Enums;
using Exercise3.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Data.EF
{
    public class Exercise3DbContext : IdentityDbContext<Users,UsersRole, Guid>
    {
        public Exercise3DbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure using Fluent API
            modelBuilder.ApplyConfiguration(new AgreementsConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());

            /*  modelBuilder.Entity<Agreements>().Property(x => x.Status).HasConversion(
                  v => v.ToString(),
                  v => (Status)Enum.Parse(typeof(Status), v)
                  );
            */
            // Data Seeding
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
            modelBuilder.Seed();
           // base.OnModelCreating(modelBuilder);
        }
        public DbSet<Agreements> Agreements { get; set; }

    }
}

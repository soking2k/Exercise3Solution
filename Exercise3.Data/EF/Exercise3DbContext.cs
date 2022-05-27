using Exercise3.Data.Configurations;
using Exercise3.Data.Entities;
using Exercise3.Data.Enums;
using Exercise3.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Data.EF
{
    public class Exercise3DbContext : DbContext
    {
        public Exercise3DbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure using Fluent API
            modelBuilder.ApplyConfiguration(new AgreementsConfiguration());

          /*  modelBuilder.Entity<Agreements>().Property(x => x.Status).HasConversion(
                v => v.ToString(),
                v => (Status)Enum.Parse(typeof(Status), v)
                );
          */
            // Data Seeding
            modelBuilder.Seed();
           // base.OnModelCreating(modelBuilder);
        }
        public DbSet<Agreements> Agreements { get; set; }
    }
}

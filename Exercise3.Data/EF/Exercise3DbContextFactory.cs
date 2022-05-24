using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Data.EF
{
    public class Exercise3DbContextFactory : IDesignTimeDbContextFactory<Exercise3DbContext>
    {
        public Exercise3DbContext CreateDbContext(string[] args)
        {
            //Get connectionString
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Exercise3Db");

            var optionsBuilder = new DbContextOptionsBuilder<Exercise3DbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new Exercise3DbContext(optionsBuilder.Options);
        }
        
    }
}

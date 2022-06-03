using Exercise3.Data.Entities;
using Exercise3.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Data.Extensions
{
    public static class ModelBuilderExtensions
    {   
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agreements>().HasData(
                new Agreements() { 
                    Id = 1,
                    Status = "Invalid",
                    QuoteNumber = "Name 1", 
                    AgreementName = "Name 2",
                    AgreementType = "Name 3",
                    DistributorName = "Name 4",
                    EffectiveDate = DateTime.Now,
                    ExpirationDate  = DateTime.Now,
                    CreatedDate = DateTime.Now, 
                    DaysUntilExpiration = 1                     
                },
                    new Agreements()
                    {
                        Id = 2,
                        Status = "Published",
                        QuoteNumber = "Name 2",
                        AgreementName = "Name 3",
                        AgreementType = "Name 4",
                        DistributorName = "Name 5",
                        EffectiveDate = DateTime.Now,
                        ExpirationDate = DateTime.Now,
                        CreatedDate = DateTime.Now,
                        DaysUntilExpiration = 2
                    }

                );
            // any guid
            var roleId = new Guid("3F2354E0-4F89-11D3-9A0C-0305E82C3352");
            var adminId = new Guid("A2464FA2-6F7E-4AC9-8210-6818142A86C4");
            modelBuilder.Entity<UsersRole>().HasData(new UsersRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
            });

            var hasher = new PasswordHasher<Users>();
            modelBuilder.Entity<Users>().HasData(new Users
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "soking2k@gmail.com",
                NormalizedEmail = "soking2k@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Soking2k@123"),
                SecurityStamp = string.Empty,
           
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}

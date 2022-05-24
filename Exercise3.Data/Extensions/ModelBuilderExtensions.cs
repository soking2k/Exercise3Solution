using Exercise3.Data.Entities;
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
                    Status = Enums.Status.Invalid, 
                    QuoteNumber ="Name 1", 
                    AgreementName = "Name 2",
                    AgreementType = "Name 3",
                    DistributorName = "Name 4",
                    EffectiveDate = DateTime.Now,
                    ExpirationDate  = DateTime.Now,
                    CreatedDate = DateTime.Now, 
                    DaysUntilExpiration = "Name 5"                      
                },
                    new Agreements()
                    {
                        Id = 2,
                        Status = Enums.Status.Invalid,
                        QuoteNumber = "Name 2",
                        AgreementName = "Name 3",
                        AgreementType = "Name 4",
                        DistributorName = "Name 5",
                        EffectiveDate = DateTime.Now,
                        ExpirationDate = DateTime.Now,
                        CreatedDate = DateTime.Now,
                        DaysUntilExpiration = "Name 6"
                    }

                );
        }
    }
}

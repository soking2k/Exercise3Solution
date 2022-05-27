using Exercise3.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3.Data.Configurations
{
    public class AgreementsConfiguration : IEntityTypeConfiguration<Agreements>
    {
        public void Configure(EntityTypeBuilder<Agreements> builder)
        {
            //Cấu hình cho bảng
            builder.ToTable("Agreements");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Status).IsRequired(true);
            builder.Property(x => x.AgreementName).IsRequired(true);
            builder.Property(x => x.QuoteNumber).IsRequired(true);
            builder.Property(x => x.AgreementType).IsRequired(true);
            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.EffectiveDate).IsRequired(true);
            builder.Property(x => x.CreatedDate).IsRequired(true);
            builder.Property(x => x.DistributorName).IsRequired(true);
            builder.Property(x => x.DaysUntilExpiration
            ).IsRequired(true);
        }
    }
}

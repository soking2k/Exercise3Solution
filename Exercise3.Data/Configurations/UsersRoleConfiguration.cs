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
    public class UsersRoleConfiguration : IEntityTypeConfiguration<UsersRole>
    {
        public void Configure(EntityTypeBuilder<UsersRole> builder)
        {
            //Cấu hình cho bảng
            builder.ToTable("UsersRole");
        }
    }
}

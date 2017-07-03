using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XDT.Domain.Model;

namespace XDT.Repositories.EntityFramework
{
    /// <summary>
    /// 用户类型的数据库相关配置
    /// </summary>
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.UserName)
               .IsRequired()
               .HasMaxLength(20);
            builder.Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(c => c.LoginAccount)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(c => c.Career)
                .HasMaxLength(10);
            builder.ToTable("Users");
        }
    }
}

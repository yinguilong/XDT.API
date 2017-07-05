using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XDT.Repositories.EntityFramework
{
    /// <summary>
    /// BoxItem的数据库配置
    /// </summary>
    public class BoxItemTypeConfiguration : IEntityTypeConfiguration<BoxItem>
    {
        public void Configure(EntityTypeBuilder<BoxItem> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID)
                .IsRequired();
        }
    }
}

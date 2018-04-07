using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;

namespace XDT.Repositories.EntityFramework.Configurations
{
    public class WareItemDiscussTypeConfiguration : IEntityTypeConfiguration<WareItemDiscuss>
    {
        public void Configure(EntityTypeBuilder<WareItemDiscuss> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.Discuss)
               .IsRequired()
               .HasMaxLength(200);
            builder.Property(c => c.Additional)
               .HasMaxLength(100);
        }
    }
}

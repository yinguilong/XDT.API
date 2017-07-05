using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XDT.Repositories.EntityFramework
{
    public class WareItemDiscussTypeConfiguration : IEntityTypeConfiguration<WareItemDiscuss>
    {
        public void Configure(EntityTypeBuilder<WareItemDiscuss> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID)
                .IsRequired();
            builder.Property(c => c.Discuss)
               .IsRequired()
               .HasMaxLength(200);
            builder.Property(c => c.Additional)
               .HasMaxLength(100);
        }
    }
}

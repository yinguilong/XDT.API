using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XDT.Repositories.EntityFramework
{
    public class BoxTypeConfiguration : IEntityTypeConfiguration<Box>
    {
        public void Configure(EntityTypeBuilder<Box> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID)
                .IsRequired();
        }
    }
}

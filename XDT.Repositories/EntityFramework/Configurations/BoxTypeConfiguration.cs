using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;

namespace XDT.Repositories.EntityFramework.Configurations
{
    public class BoxTypeConfiguration : IEntityTypeConfiguration<Box>
    {
        public void Configure(EntityTypeBuilder<Box> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(c => c.ID).IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;

namespace XDT.Repositories.EntityFramework.Configurations
{
    public class PriceItemTypeConfiguration : IEntityTypeConfiguration<PriceItem>
    {
        public void Configure(EntityTypeBuilder<PriceItem> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.Price)
                .HasColumnType("numeric");
        }
    }
}

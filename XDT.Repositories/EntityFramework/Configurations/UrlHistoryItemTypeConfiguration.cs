using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;

namespace XDT.Repositories.EntityFramework.Configurations
{
    public class UrlHistoryItemTypeConfiguration : IEntityTypeConfiguration<UrlHistoryItem>
    {
        public void Configure(EntityTypeBuilder<UrlHistoryItem> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(c => c.ID).IsRequired();
            builder.Property(c => c.Url)
                .HasMaxLength(500);
        }
    }
}

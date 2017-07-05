using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XDT.Repositories.EntityFramework
{
    public class UrlHistoryItemTypeConfiguration : IEntityTypeConfiguration<UrlHistoryItem>
    {
        public void Configure(EntityTypeBuilder<UrlHistoryItem> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID)
                .IsRequired();
            builder.Property(c => c.Url)
                .HasMaxLength(500);
        }
    }
}

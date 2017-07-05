using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XDT.Repositories.EntityFramework
{
    public class WareItemTypeConfiguration : IEntityTypeConfiguration<WareItem>
    {
        public void Configure(EntityTypeBuilder<WareItem> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID)
                .IsRequired();
            builder.Property(p => p.ItemImage)
                .HasMaxLength(500);
            builder.Property(c => c.ItemName)
                .HasMaxLength(50);
            builder.Property(c => c.ListenUrl)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(c => c.CurrentPrice)
                .HasColumnType("numeric");
            builder.Property(c => c.Description)
                .HasMaxLength(500);
            builder.Property(c => c.ItemImage)
                .HasMaxLength(500);
            builder.Ignore(c => c.BoxItem);
        }
    }
}

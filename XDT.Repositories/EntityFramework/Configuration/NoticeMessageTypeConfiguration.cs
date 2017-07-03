using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XDT.Repositories.EntityFramework.Configuration
{
    public class NoticeMessageTypeConfiguration : IEntityTypeConfiguration<NoticeMessage>
    {
        public void Configure(EntityTypeBuilder<NoticeMessage> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID)
                .IsRequired();
        }
    }
}

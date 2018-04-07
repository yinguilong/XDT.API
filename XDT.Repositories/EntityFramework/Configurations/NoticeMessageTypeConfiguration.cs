using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using XDT.Domain.Model;

namespace XDT.Repositories.EntityFramework.Configurations
{
    public class NoticeMessageTypeConfiguration : IEntityTypeConfiguration<NoticeMessage>
    {
        public void Configure(EntityTypeBuilder<NoticeMessage> builder)
        {
            builder.HasKey(c => c.ID);
            builder.Property(c => c.ID)
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}

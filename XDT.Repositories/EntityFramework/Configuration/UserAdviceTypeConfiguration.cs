using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace XDT.Repositories.EntityFramework
{
    public class UserAdviceTypeConfiguration : IEntityTypeConfiguration<UserAdvice>
    {
        public void Configure(EntityTypeBuilder<UserAdvice> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(c => c.ID).IsRequired();
        }
    }
}

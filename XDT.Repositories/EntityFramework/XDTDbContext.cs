using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;
using XDT.Repositories.EntityFramework.Configurations;

namespace XDT.Repositories.EntityFramework
{
    public class XDTDbContext : DbContext
    {

        public XDTDbContext(DbContextOptions<XDTDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }
        public DbSet<Box> Box { get; set; }
        public DbSet<BoxItem> BoxItem { get; set; }
        public DbSet<WareItem> WareItem { get; set; }
        public DbSet<PriceItem> PriceItem { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UrlHistoryItem> UrlHistoryItems { get; set; }
        public DbSet<WareItemDiscuss> WareItemDiscuss { get; set; }
        public DbSet<NoticeMessage> NoticeMessage { get; set; }
        public DbSet<UserAdvice> UserAdvice { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder
                .ApplyConfiguration(new UserTypeConfiguration())
                .ApplyConfiguration(new NoticeMessageTypeConfiguration())
                .ApplyConfiguration(new BoxItemTypeConfiguration())
                .ApplyConfiguration(new BoxTypeConfiguration())
                 .ApplyConfiguration(new PriceItemTypeConfiguration())
                  .ApplyConfiguration(new UrlHistoryItemTypeConfiguration())
                   .ApplyConfiguration(new UserAdviceTypeConfiguration())
                    .ApplyConfiguration(new WareItemDiscussTypeConfiguration())
                     .ApplyConfiguration(new WareItemTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

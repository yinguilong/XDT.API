using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XDT.Domain.Model;


namespace XDT.Repositories.EntityFramework
{
   public class XDTDbContext : DbContext
    {

        public XDTDbContext(DbContextOptions<XDTDbContext> options)
            : base(options)
        {
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
            //modelBuilder
            //    .ApplyConfiguration
            //    .Add(new UserTypeConfiguration())
            //    .Add(new PPBoxItemTypeConfiguration())
            //    .Add(new PPBoxTypeConfiguration())
            //    .Add(new PPismItemTypeConfiguration())
            //    .Add(new PriceItemTypeConfiguration())
            //    .Add(new UrlHistoryItemConfiguration())
            //    .Add(new PPismItemDiscussConfiguration())
            //    .Add(new NoticeMessageTypeConfiguration())
            //     .Add(new UserAdviceTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

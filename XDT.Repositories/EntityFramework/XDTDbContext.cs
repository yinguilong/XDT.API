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
            Database.EnsureCreated();
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
            modelBuilder.Entity<User>().HasKey(x => x.ID);
            modelBuilder.Entity<User>().Property(c => c.ID).IsRequired();
            modelBuilder.Entity<User>().Property(c => c.ID).IsRequired();
            modelBuilder.Entity<User>().Property(c => c.UserName)
               .IsRequired()
               .HasMaxLength(20);
            modelBuilder.Entity<User>().Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<User>().Property(c => c.LoginAccount)
                .IsRequired()
                .HasMaxLength(30);
            modelBuilder.Entity<User>().Property(c => c.Career)
                .HasMaxLength(10);
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<BoxItem>().HasKey(c => c.ID);
            modelBuilder.Entity<BoxItem>().Property(c => c.ID)
                .IsRequired();
            modelBuilder.Entity<Box>().HasKey(c => c.ID);
            modelBuilder.Entity<Box>().Property(c => c.ID)
                .IsRequired();
            modelBuilder.Entity<NoticeMessage>().HasKey(c => c.ID);
            modelBuilder.Entity<NoticeMessage>().Property(c => c.ID)
                .IsRequired();
            modelBuilder.Entity<PriceItem>().HasKey(c => c.ID);
            modelBuilder.Entity<PriceItem>().Property(c => c.ID)
                .IsRequired();
            modelBuilder.Entity<PriceItem>().Property(c => c.Price)
                .HasColumnType("numeric");
            modelBuilder.Entity<UrlHistoryItem>().HasKey(c => c.ID);
            modelBuilder.Entity<UrlHistoryItem>().Property(c => c.ID)
                .IsRequired();
            modelBuilder.Entity<UrlHistoryItem>().Property(c => c.Url)
                .HasMaxLength(500);
            modelBuilder.Entity<UserAdvice>().HasKey(x => x.ID);
            modelBuilder.Entity<UserAdvice>().Property(c => c.ID).IsRequired();

            modelBuilder.Entity<WareItemDiscuss>().HasKey(c => c.ID);
            modelBuilder.Entity<WareItemDiscuss>().Property(c => c.ID)
                .IsRequired();
            modelBuilder.Entity<WareItemDiscuss>().Property(c => c.Discuss)
               .IsRequired()
               .HasMaxLength(200);
            modelBuilder.Entity<WareItemDiscuss>().Property(c => c.Additional)
               .HasMaxLength(100);

            modelBuilder.Entity<WareItem>().HasKey(c => c.ID);
            modelBuilder.Entity<WareItem>().Property(c => c.ID)
                .IsRequired();
            modelBuilder.Entity<WareItem>().Property(p => p.ItemImage)
                .HasMaxLength(500);
            modelBuilder.Entity<WareItem>().Property(c => c.ItemName)
                .HasMaxLength(50);
            modelBuilder.Entity<WareItem>().Property(c => c.ListenUrl)
                .IsRequired()
                .HasMaxLength(500);
            modelBuilder.Entity<WareItem>().Property(c => c.CurrentPrice)
                .HasColumnType("numeric");
            modelBuilder.Entity<WareItem>().Property(c => c.Description)
                .HasMaxLength(500);
            modelBuilder.Entity<WareItem>().Property(c => c.ItemImage)
                .HasMaxLength(500);
            modelBuilder.Entity<WareItem>().Ignore(c => c.BoxItem);
            //modelBuilder
            //    .ApplyConfiguration(new UserTypeConfiguration())
            //    .ApplyConfiguration(new NoticeMessageTypeConfiguration())
            //    .ApplyConfiguration(new BoxItemTypeConfiguration())
            //    .ApplyConfiguration(new BoxTypeConfiguration())
            //     .ApplyConfiguration(new PriceItemTypeConfiguration())
            //      .ApplyConfiguration(new UrlHistoryItemTypeConfiguration())
            //       .ApplyConfiguration(new UserAdviceTypeConfiguration())
            //        .ApplyConfiguration(new WareItemDiscussTypeConfiguration())
            //         .ApplyConfiguration(new WareItemTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

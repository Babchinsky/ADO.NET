﻿using Book_Store.Entities;
using Book_Store.Entities.Configurations;
using Book_Store.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace Book_Store
{
    public class BookStoreContext : DbContext
    {
        public static readonly LoggerFactory MyLoggerFactory = new(new ILoggerProvider[]
            { new LogEntryLoggerProvider(), new NLogLoggerProvider() });

        public BookStoreContext()
        {
            // Database.Migrate();
        }

        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookDiscount> BookDiscounts { get; set; }
        public virtual DbSet<ContinuationBook> ContinuationBooks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DecommissionedBook> DecommissionedBooks { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationManager().AddJsonFile("appsettings.json").Build();

            if (!optionsBuilder.IsConfigured)
                optionsBuilder
                    .UseLoggerFactory(MyLoggerFactory)
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookDiscountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContinuationBookEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DecommissionedBookEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenreEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ImageEntityTypeConfiguration());

            modelBuilder.SeedData();
        }
    }
}
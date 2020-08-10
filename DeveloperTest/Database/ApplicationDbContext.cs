using System;
using Microsoft.EntityFrameworkCore;
using DeveloperTest.Database.Models;

namespace DeveloperTest.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
                .HasKey(x => x.JobId);

            modelBuilder.Entity<Job>()
                .Property(x => x.JobId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Job>()
                .HasData(new Job
                {
                    JobId = 1,
                    Engineer = "Test",
                    When = DateTime.Now
                });

            modelBuilder.Entity<Customer>()
                .HasKey(x => x.CustomerId);
            modelBuilder.Entity<Customer>()
                .Property(x => x.CustomerId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>()
                .HasMany(x => x.Jobs)
                .WithOne(x => x.Customer);

            var customerType = modelBuilder.Entity<CustomerType>();
            customerType.HasKey(x => x.CustomerTypeId);
            customerType.Property(x => x.CustomerTypeId);
            customerType.HasMany(x => x.Customers)
                .WithOne(x => x.CustomerType);
            customerType.HasData(
                    new[]
                    {
                        new CustomerType{Name = "Long", CustomerTypeId=1},
                        new CustomerType{Name = "Short", CustomerTypeId=2}
                    }
                );

        }
    }
}

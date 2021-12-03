using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Models;
using Microsoft.EntityFrameworkCore;

namespace ATM.Services.DataModels
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=localhost\SQLEXPRESS;Database=bankingAppDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Customer>(entity =>
                {
                    entity.Property(m => m.Id);
                    entity.Property(m => m.Name);
                    entity.Property(m => m.accountStatus);
                    entity.Property(m => m.Balance);
                    entity.Property(m => m.BankId);
                    entity.Property(m => m.Password);
                });
        }
    }
}

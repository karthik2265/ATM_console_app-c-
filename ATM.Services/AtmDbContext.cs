using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Models;
using Microsoft.EntityFrameworkCore;

namespace ATM.Services.DataModels
{
    public class AtmDbContext : DbContext
    {
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Bank> Banks { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=localhost\SQLEXPRESS;Database=bankingAppDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(m => m.Id);
                entity.Property(m => m.Name);
                entity.Property(m => m.BankId);
                entity.Property(m => m.Password);
            });

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

            modelBuilder.Entity<Bank>().ToTable("Bank");
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.Property(m => m.Id);
                entity.Property(m => m.Name);
                entity.Property(m => m.RTGSChargeToSameBank);
                entity.Property(m => m.IMPSChargeToSameBank);
                entity.Property(m => m.RTGSChargeToOtherBanks);
                entity.Property(m => m.IMPSChargeToOtherBanks);
                entity.Property(m => m.Currency);
                entity.Property(m => m.ExchangeRate);
            });

            modelBuilder.Entity<Transaction>().ToTable("Transaction");
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(m => m.Id);
                entity.Property(m => m.SenderAccountId);
                entity.Property(m => m.RecieverAccountId);
                entity.Property(m => m.SenderBankId);
                entity.Property(m => m.Amount);
                entity.Property(m => m.Date);
                entity.Property(m => m.Type);
            });
        }
    }
}

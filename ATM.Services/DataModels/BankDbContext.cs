using Microsoft.EntityFrameworkCore;
using ATM.Models;


namespace ATM.Services.DataModels
{
    public class BankDbContext : DbContext
    {
        public DbSet<Bank> Banks;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=localhost\SQLEXPRESS;Database=bankingAppDB;Trusted_Connection=True;");

        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.Property(m => m.Name);
                entity.Property(m => m.Id);
                entity.Property(m => m.RTGSChargeToSameBank);
                entity.Property(m => m.IMPSChargeToSameBank);
                entity.Property(m => m.RTGSChargeToOtherBanks);
                entity.Property(m => m.IMPSChargeToOtherBanks);
                entity.Property(m => m.AcceptedCurrency);
                entity.Property(m => m.ExchangeRate);
            });
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class BankingDbContext : DbContext
{
    public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options) 
    { 
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); 
    }

    public DbSet<Partner> Partners { get; set; }
    public DbSet<Merchant> Merchants { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Partner>()
            .HasMany(p => p.Merchants)
            .WithOne(m => m.Partner)
            .HasForeignKey(m => m.PartnerId);

        modelBuilder.Entity<Merchant>()
            .HasMany(m => m.Transactions)
            .WithOne(t => t.Merchant)
            .HasForeignKey(t => t.MerchantId);

        // Seed initial data
        var partner = new Partner { Id = 1, Name = "Global Tech Inc." };
        modelBuilder.Entity<Partner>().HasData(partner);

        modelBuilder.Entity<Merchant>().HasData(
            new Merchant
            {
                Id = 1,
                Name = "Online SuperStore",
                BoardingDate = new DateTime(2023, 1, 15),
                Url = "https://onlinesuperstore.com",
                Country = "USA",
                Address_1 = "123 E-commerce St",
                Address_2 = "Suite 100",
                PartnerId = partner.Id
            }
        );
    }
}

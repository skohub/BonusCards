using Microsoft.EntityFrameworkCore;
using BonusCards.Domain.Entities;

namespace BonusCards.Domain.Context
{
    public class BonusCardsContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Withdraw> Withdraws { get; set; }

        public BonusCardsContext(DbContextOptions options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CardConfiguration());
            builder.Entity<Withdraw>()
                .Property(w => w.Id)
                .ValueGeneratedOnAdd();
        }
    }
}

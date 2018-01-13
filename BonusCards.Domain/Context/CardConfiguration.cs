using BonusCards.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BonusCards.Domain.Context
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            //builder.Property(b => b.Customer).IsRequired();
            //builder.Property(b => b.Organization).IsRequired();
        }
    }
}

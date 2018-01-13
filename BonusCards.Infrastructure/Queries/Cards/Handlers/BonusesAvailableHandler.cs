using System.Linq;
using BonusCards.Domain.Context;
using BonusCards.Infrastructure.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace BonusCards.Infrastructure.Queries.Cards.Handlers
{
    public class BonusesAvailableHandler : IQueryHandler<BonusesAvailable, int>
    {
        private readonly BonusCardsContext _context;

        public BonusesAvailableHandler(BonusCardsContext context)
        {
            _context = context;
        }

        public int Query(BonusesAvailable query)
        {
            var card = _context.Cards
                .Include(c => c.Purchases)
                .Include(c => c.Withdraws)
                .First(c => c.Id == query.CardId);
            return card.GetAvailableBonuses();
        }
    }
}

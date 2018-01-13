using BonusCards.Domain.Context;
using BonusCards.Domain.Entities;
using BonusCards.Infrastructure.Cqrs;

namespace BonusCards.Infrastructure.Queries.Cards.Handlers
{
    public class FindHandler : IQueryHandler<Find, Card>
    {
        private readonly BonusCardsContext _context;

        public FindHandler(BonusCardsContext context)
        {
            _context = context;
        }

        public Card Query(Find query)
        {
            var card = _context.Cards.Find(query.Id);
            return card;
        }
    }
}

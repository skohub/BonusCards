using System.Linq;
using BonusCards.Domain.Context;
using BonusCards.Infrastructure.Cqrs;
using BonusCards.Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BonusCards.Infrastructure.Queries.Cards.Handlers
{
    public class FindHandler : IQueryHandler<Find, CardDto>
    {
        private readonly BonusCardsContext _context;

        public FindHandler(BonusCardsContext context)
        {
            _context = context;
        }

        public CardDto Query(Find query)
        {
            var card = _context.Cards
                .Include(c => c.Purchases)
                .Include(c => c.Withdraws)
                .First(c => c.Id == query.Id);
            var dto = new CardDto
            {
                Id = card.Id,
                Bonuses = card.GetAvailableBonuses()
            };
            return dto;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using BonusCards.Domain.Context;
using BonusCards.Infrastructure.Cqrs;
using BonusCards.Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BonusCards.Infrastructure.Queries.Cards.Handlers
{
    public class FindAllHandler : IQueryHandler<FindAll, IEnumerable<CardDto>>
    {
        private readonly BonusCardsContext _context;

        public FindAllHandler(BonusCardsContext context)
        {
            _context = context;
        }

        public IEnumerable<CardDto> Query(FindAll query)
        {
            var dtos = _context.Cards
                .Include(c => c.Purchases)
                .Include(c => c.Withdraws)
                .Select(c => new CardDto {Id = c.Id, Bonuses = c.GetAvailableBonuses()});
            return dtos;
        }
    }
}
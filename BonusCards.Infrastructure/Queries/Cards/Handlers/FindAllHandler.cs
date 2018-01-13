using System.Collections.Generic;
using System.Linq;
using BonusCards.Domain.Context;
using BonusCards.Domain.Entities;
using BonusCards.Infrastructure.Cqrs;

namespace BonusCards.Infrastructure.Queries.Cards.Handlers
{
    public class FindAllHandler : IQueryHandler<FindAll, IEnumerable<Card>>
    {
        private readonly BonusCardsContext _context;

        public FindAllHandler(BonusCardsContext context)
        {
            _context = context;
        }

        public IEnumerable<Card> Query(FindAll query)
        {
            return _context.Cards.ToList();
            
        }
    }
}
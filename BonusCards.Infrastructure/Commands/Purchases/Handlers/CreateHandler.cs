using System.Linq;
using BonusCards.Domain.BonusCalcStrategies;
using BonusCards.Domain.Context;
using BonusCards.Infrastructure.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace BonusCards.Infrastructure.Commands.Purchases.Handlers
{
    public class CreateHandler : ICommandHandler<Create>
    {
        private readonly BonusCardsContext _context;

        public CreateHandler(BonusCardsContext context)
        {
            _context = context;
        }

        public void Handle(Create command)
        {
            var card = _context.Cards
                .Include(c => c.Purchases)
                .First(c => c.Id == command.CardId);
            card.AddPurchase(command.Price, new PercentStrategy(10));
        }
    }
}

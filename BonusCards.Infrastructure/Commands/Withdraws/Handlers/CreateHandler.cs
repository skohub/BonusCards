using System;
using System.Linq;
using BonusCards.Domain.Context;
using BonusCards.Infrastructure.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace BonusCards.Infrastructure.Commands.Withdraws.Handlers
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
            if (command.Amount < 0) throw new ArgumentException();

            var card = _context.Cards
                .Include(c => c.Purchases)
                .Include(c => c.Withdraws)
                .First(c => c.Id == command.CardId);

            card.AddWithdraw(command.Amount);
        }
    }
}

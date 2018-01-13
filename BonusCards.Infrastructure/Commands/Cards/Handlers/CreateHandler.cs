using AutoMapper;
using BonusCards.Domain.Context;
using BonusCards.Infrastructure.Cqrs;

namespace BonusCards.Infrastructure.Commands.Cards.Handlers
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
            var card = Mapper.Map<Domain.Entities.Card>(command);
            _context.Cards.Add(card);
        }
    }
}

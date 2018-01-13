using BonusCards.Domain.Context;
using BonusCards.Infrastructure.Cqrs;

namespace BonusCards.Infrastructure.Commands.Organizations.Handlers
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
            _context.Organizations.Add(new Domain.Entities.Organization {Name = command.Name});
        }
    }
}

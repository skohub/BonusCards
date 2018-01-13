using AutoMapper;
using BonusCards.Domain.Context;
using BonusCards.Domain.Entities;
using BonusCards.Infrastructure.Cqrs;

namespace BonusCards.Infrastructure.Commands.Cards.Handlers
{
    public class CreateWithCustomerHandler : ICommandHandler<CreateWithCustomer>
    {
        private readonly BonusCardsContext _context;

        public CreateWithCustomerHandler(BonusCardsContext context)
        {
            _context = context;
        }

        public void Handle(CreateWithCustomer command)
        {
            var customer = Mapper.Map<Customer>(command);
            _context.Customers.Add(customer);
            var card = new Card {Customer = customer, OrganizationId = command.OrganizationId};
            _context.Cards.Add(card);
        }
    }
}

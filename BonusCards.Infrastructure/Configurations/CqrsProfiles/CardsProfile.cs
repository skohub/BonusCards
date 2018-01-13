using System.Collections.Generic;
using BonusCards.Domain.Entities;
using BonusCards.Infrastructure.Commands.Cards;
using BonusCards.Infrastructure.Commands.Cards.Handlers;
using BonusCards.Infrastructure.Cqrs;
using BonusCards.Infrastructure.Dtos;
using BonusCards.Infrastructure.Queries.Cards;
using BonusCards.Infrastructure.Queries.Cards.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace BonusCards.Infrastructure.Configurations.CqrsProfiles
{
    public class CardsProfile : ICqrsProfile
    {
        private readonly IServiceCollection _services;

        public CardsProfile(IServiceCollection services)
        {
            _services = services;
        }

        public void ConfigureCommands()
        {
            _services.AddTransient<ICommandHandler<Create>, CreateHandler>();
            _services.AddTransient<ICommandHandler<CreateWithCustomer>, CreateWithCustomerHandler>();
        }

        public void ConfigureQueries()
        {
            _services.AddTransient<IQueryHandler<Find, CardDto>, FindHandler>();
            _services.AddTransient<IQueryHandler<FindAll, IEnumerable<CardDto>>, FindAllHandler>();
        }
    }
}

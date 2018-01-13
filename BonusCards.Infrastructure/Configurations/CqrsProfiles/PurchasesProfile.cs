using BonusCards.Infrastructure.Commands.Purchases;
using BonusCards.Infrastructure.Commands.Purchases.Handlers;
using BonusCards.Infrastructure.Cqrs;
using Microsoft.Extensions.DependencyInjection;

namespace BonusCards.Infrastructure.Configurations.CqrsProfiles
{
    public class PurchasesProfile : ICqrsProfile
    {
        private readonly IServiceCollection _services;

        public PurchasesProfile(IServiceCollection services)
        {
            _services = services;
        }

        public void ConfigureCommands()
        {
            _services.AddTransient<ICommandHandler<Create>, CreateHandler>();
        }

        public void ConfigureQueries()
        {
            
        }
    }
}

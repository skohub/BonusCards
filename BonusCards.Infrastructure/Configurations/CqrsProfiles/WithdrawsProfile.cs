using BonusCards.Infrastructure.Commands.Withdraws;
using BonusCards.Infrastructure.Commands.Withdraws.Handlers;
using BonusCards.Infrastructure.Cqrs;
using Microsoft.Extensions.DependencyInjection;

namespace BonusCards.Infrastructure.Configurations.CqrsProfiles
{
    public class WithdrawsProfile : ICqrsProfile
    {
        private readonly IServiceCollection _services;

        public WithdrawsProfile(IServiceCollection services)
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

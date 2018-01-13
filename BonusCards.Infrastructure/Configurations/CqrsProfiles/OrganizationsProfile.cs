using BonusCards.Infrastructure.Commands.Organizations;
using BonusCards.Infrastructure.Commands.Organizations.Handlers;
using BonusCards.Infrastructure.Cqrs;
using Microsoft.Extensions.DependencyInjection;

namespace BonusCards.Infrastructure.Configurations.CqrsProfiles
{
    public class OrganizationsProfile : ICqrsProfile
    {
        private readonly IServiceCollection _services;

        public OrganizationsProfile(IServiceCollection services)
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

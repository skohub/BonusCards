using BonusCards.Infrastructure.Configurations.CqrsProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace BonusCards.Infrastructure.Configurations
{
    public class CqrsConfig
    {
        public static void Configure(IServiceCollection services)
        {
            ApplyProfile(new CardsProfile(services));
            ApplyProfile(new OrganizationsProfile(services));
            ApplyProfile(new WithdrawsProfile(services));
            ApplyProfile(new PurchasesProfile(services));
        }

        private static void ApplyProfile(ICqrsProfile profile)
        {
            profile.ConfigureCommands();
            profile.ConfigureQueries();
        }
    }
}

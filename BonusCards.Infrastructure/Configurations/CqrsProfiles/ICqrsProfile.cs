namespace BonusCards.Infrastructure.Configurations.CqrsProfiles
{
    public interface ICqrsProfile
    {
        void ConfigureCommands();
        void ConfigureQueries();
    }
}

using AutoMapper;
using BonusCards.Domain.Entities;
using BonusCards.Infrastructure.Commands.Cards;

namespace BonusCards.Infrastructure.Configurations
{
    public class AutomapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Create, Card>();
                cfg.CreateMap<CreateWithCustomer, Customer>();
            });
        }
    }
}

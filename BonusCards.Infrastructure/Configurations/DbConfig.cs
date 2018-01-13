using System;
using BonusCards.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BonusCards.Infrastructure.Configurations
{
    public class DbConfig
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddEntityFrameworkSqlite()
                .AddDbContext<BonusCardsContext>(builder =>
                {
                    builder.UseSqlite(connectionString);
                });
        }

        public static void Initialize(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<BonusCardsContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}

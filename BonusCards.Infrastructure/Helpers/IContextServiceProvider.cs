using System;

namespace BonusCards.Infrastructure.Helpers
{
    public interface IContextServiceProvider
    {
        object GetService(Type serviceType);
    }
}

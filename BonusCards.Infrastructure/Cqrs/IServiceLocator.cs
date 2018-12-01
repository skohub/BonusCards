using System;

namespace BonusCards.Infrastructure.Cqrs
{
    public interface IServiceLocator
    {
        object GetService(Type serviceType);
    }
}

using System;
using BonusCards.Infrastructure.Cqrs;

namespace BonusCards.Web
{
    // ServiceLocator is used by CQRS bus to find handler
    public class ServiceLocator : IServiceLocator
    {
        private readonly IServiceProvider _services;

        public ServiceLocator(IServiceProvider services)
        {
            _services = services;
        }

        public object GetService(Type serviceType)
        {
            var result = _services.GetService(serviceType);
            if (result is null)
            {
                throw new ArgumentException();
            }

            return result;
        }
    }
}

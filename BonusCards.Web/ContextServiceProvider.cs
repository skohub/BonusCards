using System;
using BonusCards.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BonusCards.Web
{
    public class ContextServiceProvider : IContextServiceProvider
    {
        private readonly IServiceProvider _contextServices;

        public ContextServiceProvider(IServiceProvider services)
        {
            var accessor = services.GetService<IHttpContextAccessor>();
            var context = accessor.HttpContext;
            _contextServices = context.RequestServices;
        }

        public object GetService(Type serviceType)
        {
            var result = _contextServices.GetService(serviceType);
            if (result is null)
            {
                throw new ArgumentException();
            }

            return result;
        }
    }
}

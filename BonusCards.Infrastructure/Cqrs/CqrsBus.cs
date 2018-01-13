using System;
using BonusCards.Domain.Context;
using BonusCards.Infrastructure.Helpers;

namespace BonusCards.Infrastructure.Cqrs
{
    public class CqrsBus : IUnitOfWork
    {
        private readonly IContextServiceProvider _services;
        private readonly BonusCardsContext _context;

        public CqrsBus(IContextServiceProvider services, BonusCardsContext context)
        {
            _services = services;
            _context = context;
        }

        public void ExecuteCommand<TCommand>(TCommand command)
        {
            var closedInterface = typeof(ICommandHandler<>).MakeGenericType(typeof(TCommand));
            var handler = _services.GetService(closedInterface);
            ((ICommandHandler<TCommand>)handler).Handle(command);
        }

        private object GetHandler<TCommand, TResult>(Type openInterface)
        {
            var closedInterface = openInterface.MakeGenericType(typeof(TCommand), typeof(TResult));
            return _services.GetService(closedInterface);
        }

        public TResult ExecuteCommand<TCommand, TResult>(TCommand command)
        {
            var handler = GetHandler<TCommand, TResult>(typeof(ICommandHandler<,>));
            return ((ICommandHandler<TCommand, TResult>)handler).Handle(command);
        }

        public TResult Query<TQuery, TResult>(TQuery query)
        {
            var handler = GetHandler<TQuery, TResult>(typeof(IQueryHandler<,>));
            return ((IQueryHandler<TQuery, TResult>)handler).Query(query);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

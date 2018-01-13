namespace BonusCards.Infrastructure.Cqrs
{
    public interface IQueryHandler<in TQuery, out TResult>
    {
        TResult Query(TQuery query);
    }
}

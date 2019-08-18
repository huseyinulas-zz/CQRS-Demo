using System.Threading.Tasks;

namespace LNLOrder.Write.Application.Infrastructure
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}

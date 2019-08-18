using System.Threading.Tasks;

namespace LNLOrder.Write.Application.Infrastructure
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}

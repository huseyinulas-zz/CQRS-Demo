using LNLOrder.Write.Application.Abstraction;
using LNLOrder.Write.Application.Infrastructure;
using LNLOrder.Write.Domain.Entities;
using System.Threading.Tasks;

namespace LNLOrder.Write.Application.Customers
{
    public class RegisterCustomerCommandHandler : ICommandHandler<RegisterCustomerCommand>
    {
        private readonly IOrderWriteDbContext _dbContext;

        public RegisterCustomerCommandHandler(IOrderWriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(RegisterCustomerCommand command)
        {
            var customer = new Customer()
            {
                Adress = command.Adress,
                Name = command.Name,
                Email = command.Email
            };

            _dbContext.Customers.Add(customer);

            await _dbContext.SaveChangesAsync();

        }
    }
}

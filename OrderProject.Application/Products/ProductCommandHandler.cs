using LNLOrder.Write.Application.Abstraction;
using LNLOrder.Write.Application.Infrastructure;
using LNLOrder.Write.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace LNLOrder.Write.Application.Products
{
    public class ProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IOrderWriteDbContext _dbContext;

        public ProductCommandHandler(IOrderWriteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreateProductCommand command)
        {
            var product = new Product()
            {
                Price = command.Price,
                ProductName = command.ProductName
            };

            _dbContext.Products.Add(product);

            await _dbContext.SaveChangesAsync();
        }
    }
}

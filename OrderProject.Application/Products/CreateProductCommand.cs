using LNLOrder.Write.Application.Infrastructure;
using System.Collections.Generic;
using System.Text;

namespace LNLOrder.Write.Application.Products
{
    public class CreateProductCommand: ICommand
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}

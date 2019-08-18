using LNLOrder.Write.Application.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace LNLOrder.Write.Application.Customers
{
    public class RegisterCustomerCommand : ICommand
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
   }
}

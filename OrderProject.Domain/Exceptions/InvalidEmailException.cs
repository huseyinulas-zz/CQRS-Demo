using System;

namespace LNLOrder.Domain.Exceptions
{
    public class InvalidEmailException: Exception
    {
        public InvalidEmailException(string errorMessage) : base(errorMessage)
        {

        }
    }
}

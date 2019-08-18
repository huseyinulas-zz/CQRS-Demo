using LNLOrder.Domain.Exceptions;
using LNLOrder.Domain.Infrastructure;
using System.Collections.Generic;

namespace LNLOrder.Domain.ValueObjects
{
    public class Email : ValueObject
    {

        public string EmailAdress { get; private set; }

        public Email()
        {

        }

        public Email(string email)
        {
            if (!email.Contains("@"))
            {
                throw new InvalidEmailException("Invalid email address");
            }

            EmailAdress = email;

        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return EmailAdress;
        }

        public override string ToString()
        {
            return EmailAdress;
        }
    }
}

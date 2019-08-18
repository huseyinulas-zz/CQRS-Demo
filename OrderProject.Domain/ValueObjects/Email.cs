using App;
using LNLOrder.Domain.Infrastructure;
using Microsoft.AspNetCore.Mvc;
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
            if (!email.Contains("@") || email.Length <5)
            {
                var validationProblemDetails = new ValidationProblemDetails()
                {
                    Detail = "Error while creating account. Please see errors for detail.",
                    Title = "Register Error"
                };

                validationProblemDetails.Errors.Add(nameof(Email), new string[]
                {
                   "Email address length must be greater than 5 characters",
                   "Email address must be valid format"
                });

                throw new CustomApiException(validationProblemDetails);
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

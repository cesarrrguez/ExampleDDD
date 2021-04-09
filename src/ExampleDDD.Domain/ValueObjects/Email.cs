using System;
using ExampleDDD.Domain.Common;

namespace ExampleDDD.Domain.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public string EmailAddress { get; }

        // Empty constructor for EF
        protected Email() { }

        public Email(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress)) throw new ArgumentNullException(nameof(emailAddress));

            EmailAddress = emailAddress;
        }
        protected override bool EqualsCore(Email other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}

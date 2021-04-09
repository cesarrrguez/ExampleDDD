using System;
using ExampleDDD.Domain.Common;

namespace ExampleDDD.Domain.ValueObjects
{
    public class PhoneNumber : ValueObject<PhoneNumber>
    {
        public string Number { get; }

        // Empty constructor for EF
        public PhoneNumber() { }

        public PhoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number)) throw new ArgumentNullException(nameof(number));

            Number = number;
        }

        protected override bool EqualsCore(PhoneNumber other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}

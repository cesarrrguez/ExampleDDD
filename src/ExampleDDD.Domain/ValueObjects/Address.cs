using System;
using ExampleDDD.Domain.Common;

namespace ExampleDDD.Domain.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public string ZipCode { get; }

        // Empty constructor for EF
        protected Address() { }

        public Address(string street, string city, string state, string country, string zipCode)
        {
            if (string.IsNullOrWhiteSpace(street)) throw new ArgumentNullException(nameof(street));
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException(nameof(city));
            if (string.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));
            if (string.IsNullOrWhiteSpace(country)) throw new ArgumentNullException(nameof(country));
            if (string.IsNullOrWhiteSpace(zipCode)) throw new ArgumentNullException(nameof(zipCode));

            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        protected override bool EqualsCore(Address other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}

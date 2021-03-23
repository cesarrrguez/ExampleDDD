using System;
using ExampleDDD.Domain.Common;

namespace ExampleDDD.Domain.Entities
{
    public class UserAddress : Entity
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public string ZipCode { get; }
        public User User { get; }

        // Empty constructor for EF
        protected UserAddress() { }

        public UserAddress(int id, string street, string city, string state, string country, string zipCode, User user)
        {
            if (string.IsNullOrWhiteSpace(street)) throw new ArgumentNullException(nameof(street));
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException(nameof(city));
            if (string.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));
            if (string.IsNullOrWhiteSpace(country)) throw new ArgumentNullException(nameof(country));
            if (string.IsNullOrWhiteSpace(zipCode)) throw new ArgumentNullException(nameof(zipCode));

            Id = id;
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}

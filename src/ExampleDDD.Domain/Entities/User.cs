using System;
using System.Collections.Generic;
using ExampleDDD.Domain.Common;

namespace ExampleDDD.Domain.Entities
{
    public class User : Entity, IAggregateRoot
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
        public string PhoneNumber { get; set; }

        private readonly List<UserAddress> _addresses;
        public IReadOnlyCollection<UserAddress> Addresses => _addresses;

        private readonly List<UserEmail> _emails;
        public IReadOnlyCollection<UserEmail> Emails => _emails;

        // Empty constructor for EF
        protected User() { }

        public User(string firstName, string lastName, int age, string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentNullException(nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentNullException(nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;

            _addresses = new List<UserAddress>();
            _emails = new List<UserEmail>();
        }

        public void AddAddress(int id, string street, string city, string state, string country, string zipCode)
        {
            if (string.IsNullOrWhiteSpace(street)) throw new ArgumentNullException(nameof(street));
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException(nameof(city));
            if (string.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));
            if (string.IsNullOrWhiteSpace(country)) throw new ArgumentNullException(nameof(country));
            if (string.IsNullOrWhiteSpace(zipCode)) throw new ArgumentNullException(nameof(zipCode));

            var address = new UserAddress(id, street, city, state, country, zipCode, this);

            _addresses.Add(address);
        }

        public void AddEmail(int id, string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress)) throw new ArgumentNullException(nameof(emailAddress));

            var email = new UserEmail(id, emailAddress, this);

            _emails.Add(email);
        }
    }
}

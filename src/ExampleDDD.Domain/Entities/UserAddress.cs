using System;
using ExampleDDD.Domain.Common;
using ExampleDDD.Domain.ValueObjects;

namespace ExampleDDD.Domain.Entities
{
    public class UserAddress : Entity
    {
        public Address Address { get; }
        public User User { get; }

        // Empty constructor for EF
        protected UserAddress() { }

        public UserAddress(int id, Address address, User user)
        {
            Id = id;
            Address = address ?? throw new ArgumentNullException(nameof(address));
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}

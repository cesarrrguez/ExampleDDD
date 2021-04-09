using System;
using ExampleDDD.Domain.Common;
using ExampleDDD.Domain.ValueObjects;

namespace ExampleDDD.Domain.Entities
{
    public class UserEmail : Entity
    {
        public Email Email { get; }
        public User User { get; }

        // Empty constructor for EF
        protected UserEmail() { }

        public UserEmail(int id, Email email, User user)
        {
            Id = id;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}

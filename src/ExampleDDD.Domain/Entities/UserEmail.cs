using System;
using ExampleDDD.Domain.Common;

namespace ExampleDDD.Domain.Entities
{
    public class UserEmail : Entity
    {
        public string EmailAddress { get; }
        public User User { get; }

        // Empty constructor for EF
        protected UserEmail() { }

        public UserEmail(int id, string emailAddress, User user)
        {
            if (string.IsNullOrWhiteSpace(emailAddress)) throw new ArgumentNullException(nameof(emailAddress));

            Id = id;
            EmailAddress = emailAddress;
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}

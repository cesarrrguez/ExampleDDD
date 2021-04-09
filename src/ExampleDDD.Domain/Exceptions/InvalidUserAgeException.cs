using System;

namespace ExampleDDD.Domain.Exceptions
{
    public class InvalidUserAgeException : Exception
    {
        public InvalidUserAgeException() : base() { }

        public InvalidUserAgeException(string message) : base(message) { }

        public InvalidUserAgeException(string message, Exception innerException) : base(message, innerException) { }
    }
}

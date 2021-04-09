using System;

namespace ExampleDDD.Domain.Exceptions
{
    public class InvalidUserStateException : Exception
    {
        public InvalidUserStateException() : base() { }

        public InvalidUserStateException(string message) : base(message) { }

        public InvalidUserStateException(string message, Exception innerException) : base(message, innerException) { }
    }
}

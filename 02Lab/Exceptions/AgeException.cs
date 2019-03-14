using System;

namespace _Laboratory02.Exceptions
{
   internal class AgeException : Exception
    {
        public AgeException(string message)
            : base(message)
        { }
    }
}

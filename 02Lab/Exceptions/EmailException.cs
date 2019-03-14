
using System;

namespace _Laboratory02.Exceptions
{
   internal class EmailException : Exception
    {
        public EmailException(string message)
            : base(message)
        { }
    }
}

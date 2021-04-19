using System;

namespace CalulaJuros.Domain.Exceptions
{
    public class CoreException : Exception
    {
        public CoreException(string message) : base(message)
        {
        }

        public CoreException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public CoreException(Exception innerException) : base(null, innerException)
        {
        }
    }
}
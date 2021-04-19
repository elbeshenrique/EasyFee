using System;

namespace CalculaJuros.Domain.Exceptions
{

    public class CalculateCompositeFeeUsecaseException : CoreException
    {
        public CalculateCompositeFeeUsecaseException(Exception innerException) : base(innerException)
        {
        }
    }
}
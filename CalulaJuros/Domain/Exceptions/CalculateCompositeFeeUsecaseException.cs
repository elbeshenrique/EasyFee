using System;

namespace CalulaJuros.Domain.Exceptions
{

    public class CalculateCompositeFeeUsecaseException : CoreException
    {
        public CalculateCompositeFeeUsecaseException(Exception innerException) : base(innerException)
        {
        }
    }
}
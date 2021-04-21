using System;

namespace CalculateFee.Domain.Exceptions
{

    public class CalculateCompositeFeeUsecaseException : CoreException
    {
        public CalculateCompositeFeeUsecaseException(Exception innerException) : base(innerException)
        {
        }
    }
}
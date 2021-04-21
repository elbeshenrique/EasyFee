using System;

namespace CalculateFee.Domain.Exceptions
{

    public class FeePercentageServiceException : CoreException
    {
        private const string FeePercentageServiceFailureMessage = "Falha ao solicitar o valor da taxa de juros.";

        public FeePercentageServiceException() : base(FeePercentageServiceFailureMessage)
        {
        }

        public FeePercentageServiceException(Exception innerException) : base(FeePercentageServiceFailureMessage, innerException)
        {
        }
    }
}
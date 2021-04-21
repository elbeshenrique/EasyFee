using System;
using System.Threading.Tasks;
using CalculateFee.Domain.Exceptions;
using CalculateFee.Domain.Services;
using CalculateFee.Domain.Usecases;

namespace CalculateFee.Usecases
{
    public class CalculateCompositeFeeUsecase : ICalculateFeeUsecase
    {
        private readonly IFeePercentageService feePercentageService;

        public CalculateCompositeFeeUsecase(IFeePercentageService feePercentageService)
        {
            this.feePercentageService = feePercentageService;
        }

        public async Task<decimal> Execute(decimal initialValue, int months)
        {
            try
            {
                var feePercentage = await feePercentageService.GetFeePercentage();
                var finalValue = CalculateCompositeFee(initialValue, months, feePercentage);
                finalValue = Truncate(finalValue);
                return finalValue;
            }
            catch (Exception exception)
            {
                throw new CalculateCompositeFeeUsecaseException(exception);
            }
        }

        private decimal CalculateCompositeFee(decimal initialValue, int months, decimal feePercentage)
        {
            decimal secondPart = Convert.ToDecimal(Math.Pow(1d + (double)feePercentage, months));
            return initialValue * secondPart;
        }

        private decimal Truncate(decimal value)
        {
            return Math.Truncate(value * 100) / 100;
        }
    }
}
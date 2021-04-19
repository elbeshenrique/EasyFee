using System;
using System.Threading.Tasks;
using CalulaJuros.Domain.Exceptions;
using CalulaJuros.Domain.Services;
using CalulaJuros.Domain.Usecases;

namespace CalulaJuros.Usecases
{
    public class CalculateCompositeFeeUsecase : ICalculateFeeUsecase
    {
        private readonly IFeePercentageService taxaJurosService;

        public CalculateCompositeFeeUsecase(IFeePercentageService taxaJurosService)
        {
            this.taxaJurosService = taxaJurosService;
        }

        public async Task<decimal> Execute(decimal initialValue, int time)
        {
            try
            {
                var feePercentage = await taxaJurosService.GetFeePercentage();
                var finalValue = CalculateCompositeFee(initialValue, time, feePercentage);
                finalValue = Truncate(finalValue);
                return finalValue;
            }
            catch (Exception exception)
            {
                throw new CalculateCompositeFeeUsecaseException(exception);
            }
        }

        private decimal CalculateCompositeFee(decimal initialValue, int time, decimal feePercentage)
        {
            decimal secondPart = Convert.ToDecimal(Math.Pow(1d + (double)feePercentage, time));
            return initialValue * secondPart;
        }

        private decimal Truncate(decimal value)
        {
            return Math.Truncate(value * 100) / 100;
        }
    }
}
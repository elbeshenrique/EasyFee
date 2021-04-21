using FeePercentage.Domain.Usecases;

namespace FeePercentage.Application.Usecases
{
    public class GetCompositeFeePercentageUsecase : IGetFeePercentageUsecase
    {
        private const decimal FeePercentage = 0.01M;

        public decimal Execute()
        {
            return FeePercentage;
        }
    }
}
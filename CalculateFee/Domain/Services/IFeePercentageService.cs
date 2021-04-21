using System.Threading.Tasks;

namespace CalculateFee.Domain.Services
{
    public interface IFeePercentageService
    {
        Task<decimal> GetFeePercentage();
    }
}
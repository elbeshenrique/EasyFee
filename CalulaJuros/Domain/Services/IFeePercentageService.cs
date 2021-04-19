using System.Threading.Tasks;

namespace CalulaJuros.Domain.Services
{
    public interface IFeePercentageService
    {
        Task<decimal> GetFeePercentage();
    }
}
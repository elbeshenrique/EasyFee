using System.Threading.Tasks;

namespace CalculaJuros.Domain.Services
{
    public interface IFeePercentageService
    {
        Task<decimal> GetFeePercentage();
    }
}
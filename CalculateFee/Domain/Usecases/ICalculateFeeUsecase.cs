using System.Threading.Tasks;

namespace CalculateFee.Domain.Usecases
{
    public interface ICalculateFeeUsecase
    {
         Task<decimal> Execute(decimal initialValue, int months);
    }
}
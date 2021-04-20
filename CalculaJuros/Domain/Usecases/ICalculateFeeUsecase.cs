using System.Threading.Tasks;

namespace CalculaJuros.Domain.Usecases
{
    public interface ICalculateFeeUsecase
    {
         Task<decimal> Execute(decimal initialValue, int months);
    }
}
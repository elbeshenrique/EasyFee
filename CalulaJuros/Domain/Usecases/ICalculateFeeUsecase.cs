using System.Threading.Tasks;

namespace CalulaJuros.Domain.Usecases
{
    public interface ICalculateFeeUsecase
    {
         Task<decimal> Execute(decimal initialValue, int time);
    }
}
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculateFee.Application.Drivers
{
    public interface IHttpHandler
    {
        Task<string> GetAsyncAsString(string requestUri);
    }
}
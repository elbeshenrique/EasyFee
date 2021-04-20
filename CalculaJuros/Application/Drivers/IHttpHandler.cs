using System.Net.Http;
using System.Threading.Tasks;

namespace CalculaJuros.Application.Drivers
{
    public interface IHttpHandler
    {
        Task<string> GetAsyncAsString(string requestUri);
    }
}
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculateFee.Application.Drivers
{
    public class HttpClientHandler : IHttpHandler
    {
        private readonly HttpClient client;

        public HttpClientHandler(HttpClient client)
        {
            this.client = client;
        }

        public async Task<string> GetAsyncAsString(string requestUri)
        {
            var response = await client.GetAsync(requestUri);
            var rawValue = await response.Content.ReadAsStringAsync();
            return rawValue;
        }
    }
}
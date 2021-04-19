using System;
using System.Net.Http;
using System.Threading.Tasks;
using CalulaJuros.Constants;
using CalulaJuros.Domain.Exceptions;
using CalulaJuros.Domain.Services;

namespace CalulaJuros.Services
{
    public class FeePercentageService : IFeePercentageService
    {
        private const string UrlEndpointFormat = "http://{0}:6000/taxaJuros";
        
        private readonly string urlEndpoint;

        public FeePercentageService() {
            var hostIp = Environment.GetEnvironmentVariable(EnvironmentVariables.HostIp);
            urlEndpoint = String.Format(UrlEndpointFormat, hostIp);
        }

        public async Task<decimal> GetFeePercentage()
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(urlEndpoint);
                var rawValue = await response.Content.ReadAsStringAsync();
                var feePercentage = Convert.ToDecimal(rawValue);
                return feePercentage;
            }
            catch (Exception exception)
            {
                throw new FeePercentageServiceException(exception);
            }
        }
    }
}
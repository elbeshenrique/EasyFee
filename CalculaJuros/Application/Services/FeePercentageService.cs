using System;
using System.Net.Http;
using System.Threading.Tasks;
using CalculaJuros.Application.Drivers;
using CalculaJuros.Domain.Exceptions;
using CalculaJuros.Domain.Services;

namespace CalculaJuros.Services
{
    public class FeePercentageService : IFeePercentageService
    {
        public const string UrlEndpointFormat = "http://{0}:6000/taxaJuros";

        private readonly IHttpHandler httpHandler;
        private readonly string urlEndpoint;

        public FeePercentageService(IHttpHandler httpHandler, string urlEndpoint)
        {
            this.urlEndpoint = urlEndpoint;
            this.httpHandler = httpHandler;
        }

        public async Task<decimal> GetFeePercentage()
        {
            try
            {
                var rawValue = await httpHandler.GetAsyncAsString(urlEndpoint);
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
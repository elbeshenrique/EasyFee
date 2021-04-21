using System;
using System.Net.Http;
using System.Threading.Tasks;
using CalculateFee.Application.Drivers;
using CalculateFee.Domain.Exceptions;
using CalculateFee.Domain.Services;

namespace CalculateFee.Services
{
    public class FeePercentageService : IFeePercentageService
    {
        public const string UrlEndpointFormat = "http://{0}:7000/taxaJuros";

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
using System;
using System.Net.Http;
using System.Threading.Tasks;
using CalulaJuros.Domain.Exceptions;

namespace CalulaJuros.Services
{
    public class FeePercentageService
    {
        private const string Url = "http://localhost:6000/taxaJuros";

        public async Task<decimal> GetFeePercentage()
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync("Url");
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
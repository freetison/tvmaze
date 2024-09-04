using Flurl.Http;
using Flurl.Http.Configuration;

using TvMaze.HttpServiceProvider.Models.RapidApi;

namespace TvMaze.HttpServiceProvider.Services
{
    public class RapidApiClient(IFlurlClientCache clients) : IRapidApiClient
    {
        private readonly IFlurlClient _flurlCli = clients.Get("RapidApi");

        public async Task<ExchangeRates> GetExchangeRates()
        {
            return await _flurlCli
                .Request("latest")
                // .SetQueryParams(new { from = "USD", to = "EUR%252CGBP" })
                .GetJsonAsync<ExchangeRates>();
        }

        public async Task<ConvertRate> GetConvertRate(string from, string to, decimal amount)
        {
            return await _flurlCli
                .Request("convert")
                .SetQueryParams(new { from, to, amount })
                .GetJsonAsync<ConvertRate>();
        }
    }

}
using TvMaze.HttpServiceProvider.Models.RapidApi;

namespace TvMaze.HttpServiceProvider.Services;

public interface IRapidApiClient
{
    Task<ExchangeRates> GetExchangeRates();
    Task<ConvertRate> GetConvertRate(string from, string to, decimal amount);

}
using MediatR;

using TvMaze.HttpServiceProvider.Models.RapidApi;

namespace TvMaze.HttpWorker.EventHandlers
{
    public class ExchangeRatesEvent(ExchangeRates data) : INotification
    {
        public ExchangeRates Data { get; set; } = data;
    }

}
namespace TvMaze.HttpServiceProvider.DependencyInjection
{
    using Flurl.Http;
    using Flurl.Http.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TvMaze.HttpServiceProvider;

    public static class ConfigureHttpService
    {
        public static IServiceCollection AddHttpProviders(this IServiceCollection services, string baseUrl)
        {
            services.AddSingleton(sp => new FlurlClientCache()
                .Add("TvMazeApi", baseUrl, builder => builder
                .WithSettings(s => s.Timeout = TimeSpan.FromSeconds(10))
                .WithHeaders(new Dictionary<string, object?>
                    {
                        { "Content-Type", "application/json" },
                        { "Accept", "*/*" },
                    })
                .BeforeCall(c => Console.WriteLine($"Calling: {c.Request.Url}"))));

            services.AddTransient<ITvMazeApiClient, TvMazeApiClient>();
            return services;
        }
    }
}
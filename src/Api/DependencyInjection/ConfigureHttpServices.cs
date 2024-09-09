namespace TvMaze.Api.DependencyInjection
{
    using System.Text;
    using RestSharp;
    using TvMaze.Application.Infrastructure.Utils;
    using TvMaze.ShareCommon.Models.Settings;

    /// <summary>
    /// Defines the <see cref="ConfigureHttpServices" />.
    /// </summary>
    public static class ConfigureHttpServices
    {
        /// <summary>
        /// The AddHttpServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="appSettings">The appSettings<see cref="AppSettings"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddHttpServices(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton<IRestClient>(sp =>
            {
                var baseUrl = appSettings?.ExternalApi?.BaseUrl ?? string.Empty;

                var options = new RestClientOptions(baseUrl)
                {
                    RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,

                    Encoding = Encoding.UTF8,
                    Interceptors = [new BeforeCallInterceptor()],
                };

                var restClient = new RestClient(options);
                restClient.AddDefaultHeader("Content-Type", "application/json");
                restClient.AddDefaultHeader("Accept", "*/*");

                return restClient;
            });

            return services;
        }
    }
}
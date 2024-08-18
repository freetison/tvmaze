using System.Text;

using RestSharp;

using TvMaze.Application.Common.Models.Settings;
using TvMaze.Application.Infrastructure.Utils;

namespace TvMaze.Api.DependencyInjection
{
    /// <summary>
    /// Defines the <see cref="ConfigureHttpServices" />.
    /// </summary>
    public static class ConfigureHttpServices
    {
        /// <summary>
        /// The AddHttpServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="apiSettings">The apiSettings<see cref="ApiSettings"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddHttpServices(this IServiceCollection services, ApiSettings apiSettings)
        {
            services.AddSingleton<IRestClient>(sp =>
            {
                var baseUrl = apiSettings?.ExternalApi?.BaseUrl ?? string.Empty;

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

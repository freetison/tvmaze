namespace TvMaze.Api.DependencyInjection
{
    using Microsoft.AspNetCore.HttpLogging;

    /// <summary>
    /// Defines the <see cref="ConfigureLoggingServices" />.
    /// </summary>
    public static class ConfigureLoggingServices
    {
        /// <summary>
        /// The AddApiLogging.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddApiLogging(this IServiceCollection services)
        {
            services.AddLogging();

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Production")
            {
                services.AddHttpLogging(httpLogging =>
                {
                    // only for dev
                    httpLogging.LoggingFields = HttpLoggingFields.RequestPropertiesAndHeaders |
                                                HttpLoggingFields.RequestBody |
                                                HttpLoggingFields.ResponsePropertiesAndHeaders |
                                                HttpLoggingFields.ResponseBody;
                    httpLogging.MediaTypeOptions.AddText("application/javascript");
                    httpLogging.RequestBodyLogLimit = 4096;
                    httpLogging.ResponseBodyLogLimit = 4096;
                });
            }

            return services;
        }
    }
}
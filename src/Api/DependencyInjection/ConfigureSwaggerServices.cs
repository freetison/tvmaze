using Microsoft.OpenApi.Models;

using TvMaze.Application.Common.Models.Settings;

namespace TvMaze.Api.DependencyInjection
{
    /// <summary>
    /// Defines the <see cref="ConfigureSwaggerServices" />.
    /// </summary>
    public static class ConfigureSwaggerServices
    {
        /// <summary>
        /// The AddSwaggerServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddSwaggerService(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.GetSection("ApiSettings").Get<ApiSettings>();
            services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = appSettings?.ApiTitle,
                Version = appSettings?.ApiVersion,
                Description = appSettings?.ApiDescription,
            });

            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{AppDomain.CurrentDomain.FriendlyName}.xml"));
        });

            return services;
        }
    }
}

namespace TvMaze.Api.DependencyInjection
{
    using Microsoft.OpenApi.Models;
    using TvMaze.Application.Common.Models.Settings;

    /// <summary>
    /// Defines the <see cref="ConfigureSwaggerServices" />.
    /// </summary>
    public static class ConfigureSwaggerServices
    {
        /// <summary>
        /// The AddSwaggerServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="apiSettings">The apiSettings<see cref="ApiSettings"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddSwaggerService(this IServiceCollection services, ApiSettings apiSettings)
        {
            services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = apiSettings?.ApiTitle,
                Version = apiSettings?.ApiVersion,
                Description = apiSettings?.ApiDescription,
            });

            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{AppDomain.CurrentDomain.FriendlyName}.xml"));
        });

            return services;
        }
    }
}
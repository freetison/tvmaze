namespace TvMaze.Api.DependencyInjection
{
    using Microsoft.OpenApi.Models;
    using TvMaze.ShareCommon.Models.Settings;

    /// <summary>
    /// Defines the <see cref="ConfigureSwaggerServices" />.
    /// </summary>
    public static class ConfigureSwaggerServices
    {
        /// <summary>
        /// The AddSwaggerServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="appSettings">The appSettings<see cref="AppSettings"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddSwaggerService(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = appSettings?.AppInfo.ApiTitle,
                Version = appSettings?.AppInfo.ApiVersion,
                Description = appSettings?.AppInfo.ApiDescription,
            });

            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{AppDomain.CurrentDomain.FriendlyName}.xml"));
        });

            return services;
        }
    }
}
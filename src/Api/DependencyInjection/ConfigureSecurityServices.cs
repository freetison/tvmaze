namespace TvMaze.Api.DependencyInjection
{
    using System.Threading.RateLimiting;
    using TvMaze.ShareCommon.Models.Settings;

    /// <summary>
    /// Defines the <see cref="ConfigureSecurityServices" />.
    /// </summary>
    public static class ConfigureSecurityServices
    {
        /// <summary>
        /// The AddSecurityServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="appSettings">The appSettings<see cref="AppSettings"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddSecurityServices(this IServiceCollection services, AppSettings appSettings)
        {
            services
                 .AddRateLimiter(options =>
                 {
                     options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(
                         _ => RateLimitPartition.GetFixedWindowLimiter(
                             "global",
                             _ => new FixedWindowRateLimiterOptions
                             {
                                 PermitLimit = 100,
                                 Window = TimeSpan.FromMinutes(1),
                             }));
                 })
                 .AddCors(options => options.AddDefaultPolicy(
                    policy => policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()))
                .AddAuthorization(options =>
                {
                    options.AddPolicy("ApiKeyPolicy", policy =>
                    {
                        policy.RequireAssertion(context =>
                        {
                            if (context.Resource is HttpContext httpContext)
                            {
                                return httpContext.Request.Headers.TryGetValue("X-API-KEY", out var extractedApiKey) &&
                                       extractedApiKey == appSettings.Options.ApiKey;
                            }

                            return false;
                        });
                    });
                });

            return services;
        }
    }
}
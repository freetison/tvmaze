using System.Threading.RateLimiting;

using TvMaze.Application.Common.Models.Settings;

namespace TvMaze.Api.DependencyInjection
{
    /// <summary>
    /// Defines the <see cref="ConfigureSecurityServices" />.
    /// </summary>
    public static class ConfigureSecurityServices
    {
        /// <summary>
        /// The AddSecurityServices.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="apiSettings">The apiSettings<see cref="ApiSettings"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddSecurityServices(this IServiceCollection services, ApiSettings apiSettings)
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
                                       extractedApiKey == apiSettings.Options.ApiKey;
                            }

                            return false;
                        });
                    });
                });

            return services;
        }
    }
}

using System.Threading.RateLimiting;

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
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddSecurityServices(this IServiceCollection services)
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
                .AllowAnyMethod()));

            return services;
        }
    }
}

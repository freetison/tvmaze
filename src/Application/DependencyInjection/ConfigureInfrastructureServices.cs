using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using StackExchange.Redis;

using TvMaze.Application.Common.Exceptions;
using TvMaze.Application.Common.Interfaces;
using TvMaze.Application.Common.Models.Settings;
using TvMaze.Application.Infrastructure.Files;
using TvMaze.Application.Infrastructure.Persistence;
using TvMaze.Application.Infrastructure.Services;

namespace TvMaze.Application.DependencyInjection
{
    /// <summary>
    /// Defines the <see cref="ConfigureInfrastructureServices" />.
    /// </summary>
    public static class ConfigureInfrastructureServices
    {
        /// <summary>
        /// Defines the DatabaseName.
        /// </summary>
        private const string DatabaseName = "TvMaze";

        /// <summary>
        /// The AddInfrastructure.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="configuration">The configuration<see cref="IConfiguration"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection("ApiSettings").Get<ApiSettings>();
            if (settings == null)
            {
                throw new NoConfigurationException();
            }

            if (settings.Options.UseInMemoryDatabase)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase(DatabaseName));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseSqlServer(
                      settings.ConnectionStrings.SqlServer,
                      sqlServerOptionsAction: sqlOptions => sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                return ConnectionMultiplexer.Connect(settings.ConnectionStrings.Redis);
            });

            services.AddScoped<IDomainEventService, DomainEventService>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}

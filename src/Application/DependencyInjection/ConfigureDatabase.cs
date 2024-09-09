namespace TvMaze.Application.DependencyInjection
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using TvMaze.Application.Infrastructure.Persistence;
    using TvMaze.ShareCommon.Models.Settings;

    /// <summary>
    /// Defines the <see cref="ConfigureDatabase" />.
    /// </summary>
    public static class ConfigureDatabase
    {
        /// <summary>
        /// Defines the DatabaseName.
        /// </summary>
        private const string DatabaseName = "TvMaze";

        /// <summary>
        /// The AddSqlserver.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <param name="appSettings">The appSettings<see cref="AppSettings"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddSqlserver(this IServiceCollection services, AppSettings appSettings)
        {
            if (appSettings.Options.UseInMemoryDatabase)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase(DatabaseName));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseSqlServer(
                      appSettings.ConnectionStrings.SqlServer,
                      sqlServerOptionsAction: sqlOptions => sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            return services;
        }
    }
}
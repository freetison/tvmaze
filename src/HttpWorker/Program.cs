using TvMaze.HttpWorker.DependencyInjection;
using TvMaze.ShareCommon.Models.Settings;

/// <summary>
/// Defines the <see cref="Program" />.
/// </summary>
internal class Program
{
    /// <summary>
    /// The Main.
    /// </summary>
    /// <param name="args">The args.</param>
    private static void Main(string[] args)
    {
        IHostBuilder builder = Host.CreateDefaultBuilder(args);
        builder
            .UseEnvironment(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development")
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                config.AddEnvironmentVariables();
                config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
                config.AddJsonFile("Secrets.json", optional: true, reloadOnChange: true);
            })
            .ConfigureServices((hostContext, services) =>
            {
                var configuration = hostContext.Configuration;

                // Bind the configuration to the AppSettings class
                var appSettings = new AppSettings();
                configuration.GetSection("AppSettings").Bind(appSettings);

                appSettings.CheckConfigurations();

                // Configure services
                ConfigureAppServices.ConfigureServices(services, appSettings);
            });

        IHost host = builder.Build();

        host.Run();
    }
}
namespace TvMaze.Application.DependencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using TvMaze.Application.Common.Interfaces;
    using TvMaze.Application.Infrastructure.Services;

    public static class ConfigureAppServices
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddTransient<IDateTime, DateTimeService>();

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            // services.AddSingleton<IMessageSender, MessageSender>();
            return services;
        }
    }
}

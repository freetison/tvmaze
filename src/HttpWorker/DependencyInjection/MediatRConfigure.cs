using System.Reflection;



namespace TvMaze.HttpWorker.DependencyInjection
{
    public static class MediatRConfigure
    {
        public static object AddAddMediatRService(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }

    }
}

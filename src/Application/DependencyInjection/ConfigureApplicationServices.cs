namespace TvMaze.Application.DependencyInjection
{
    using System.Reflection;

    using FluentValidation;

    using MediatR;

    using Microsoft.Extensions.DependencyInjection;

    using TvMaze.Application.Common.Behaviours;
    using TvMaze.Application.Common.Interfaces;
    using TvMaze.Application.Features;
    using TvMaze.Application.Features.Job.Run.EventHandlers;
    using TvMaze.Application.Infrastructure.Services;

    /// <summary>
    /// Defines the <see cref="ConfigureApplicationServices" />.
    /// </summary>
    public static class ConfigureApplicationServices
    {
        /// <summary>
        /// The AddApplication.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<InMemoryCache>();
            services.AddScoped<IDomainEventService, DomainEventService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblyContaining(typeof(IRequestHandler<,>));

                options.AddOpenBehavior(typeof(AuthorizationBehaviour<,>));
                options.AddOpenBehavior(typeof(ValidationBehaviour<,>));
                options.AddOpenBehavior(typeof(PerformanceBehaviour<,>));
                options.AddOpenBehavior(typeof(UnhandledExceptionBehaviour<,>));
            });

            // services.AddAppFeatures();
            services.AddScoped(sp => ActivatorUtilities.CreateInstance<BaseFeature>(sp));
            services.AddScoped<IRequestHandler<RunJobCommand, Unit>, RunJobCommandHandler>();

            return services;
        }
    }
}

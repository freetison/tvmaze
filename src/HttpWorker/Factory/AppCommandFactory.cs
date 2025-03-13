namespace TvMaze.HttpWorker.Factory
{
    using Microsoft.Extensions.DependencyInjection;
    using TvMaze.HttpWorker.Commands;

    /// <summary>
    public class AppCommandFactory : IAppCommandFactory
    {
        private readonly Dictionary<string, Type> _commandTypes = new();

        public void RegisterCommand<TIn, TOut>(string commandName, Type commandType)
        {
            _commandTypes[commandName] = commandType;
        }

        public IAppCommand<TIn, TOut> GetCommand<TIn, TOut>(string commandName)
        {
            if (_commandTypes.TryGetValue(commandName, out var commandType))
            {
                return (IAppCommand<TIn, TOut>)ActivatorUtilities.CreateInstance(commandType);
            }

            throw new ArgumentException($"Comando no registrado: {commandName}");
        }
    }
}
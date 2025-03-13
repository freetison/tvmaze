namespace TvMaze.HttpWorker.Factory
{
    using TvMaze.HttpWorker.Commands;

    public interface IAppCommandFactory
    {
        IAppCommand<TIn, TOut> GetCommand<TIn, TOut>(string commandName);

        void RegisterCommand<TIn, TOut>(string commandName, Type commandType);
    }
}
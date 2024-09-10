namespace TvMaze.HttpWorker.Commands
{
    public abstract class AppCommand<TIn, TOut> : IAppCommand<TIn, TOut>
    {
        public virtual string CommandName => GetType().Name;

        public abstract Task<TOut?> ProcessAsync(TIn input);
    }
}
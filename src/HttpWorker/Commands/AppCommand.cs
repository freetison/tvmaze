namespace TvMaze.HttpWorker.Commands
{
    public abstract class AppCommand<TIn, TOut> : IAppCommand<TIn, TOut>
    {
        public virtual string CommandName => GetType().Name;
        public virtual TOut Data { get; set; }

        public abstract Task<TOut> ExecuteAsync(TIn input);
    }
}
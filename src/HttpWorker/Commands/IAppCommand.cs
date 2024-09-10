namespace TvMaze.HttpWorker.Commands
{
    public interface IAppCommand<in TIn, TOut>
    {
        Task<TOut?> ProcessAsync(TIn input);
    }
}
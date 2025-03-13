namespace MediatRGenericFactory
{
    using MediatR;

    /// <summary>
    /// Defines the <see cref="IGenericFactory{TResult, TRequest}" />.
    /// </summary>
    /// <typeparam name="TResult">.</typeparam>
    /// <typeparam name="TRequest">..</typeparam>
    public interface IGenericFactory<TResult, TRequest>
    where TRequest : IRequest<TResult>
    {
        /// <summary>
        /// The Register.
        /// </summary>
        /// <param name="key">The key<see cref="string"/>.</param>
        /// <param name="creator">The creator<see cref="Func{TRequest}"/>.</param>
        void Register(string key, Func<TRequest> creator);

        /// <summary>
        /// The Execute.
        /// </summary>
        /// <param name="key">The key<see cref="string"/>.</param>
        /// <returns>The <see cref="Task{TResult}"/>.</returns>
        ValueTask<TResult> Execute(string key);
    }
}
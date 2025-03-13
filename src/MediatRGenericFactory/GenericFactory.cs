namespace MediatRGenericFactory
{
    using System.Collections.Concurrent;
    using MediatR;

    public class GenericFactory<TResult, TRequest> : IGenericFactory<TResult, TRequest>
    where TRequest : IRequest<TResult>
    {
        private readonly IMediator _mediator;
        private readonly ConcurrentDictionary<string, Func<TRequest>> _factories = new ConcurrentDictionary<string, Func<TRequest>>();

        public GenericFactory(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Register(string key, Func<TRequest> creator) => _factories.TryAdd(key, creator);

        public async ValueTask<TResult> Execute(string key)
        {
            if (_factories.TryGetValue(key, out var factory))
            {
                var request = factory();
                return await _mediator.Send(request);
            }

            return await ValueTask.FromException<TResult>(new KeyNotFoundException($"MediatR command or query not found for: '{key}'"));
        }
    }
}
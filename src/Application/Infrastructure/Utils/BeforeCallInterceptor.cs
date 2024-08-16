using System.Diagnostics;

using RestSharp.Interceptors;

namespace TvMaze.Application.Infrastructure.Utils
{
    /// <summary>
    /// Defines the <see cref="BeforeCallInterceptor" />.
    /// </summary>
    public class BeforeCallInterceptor : Interceptor
    {
        /// <summary>
        /// The BeforeHttpRequest.
        /// </summary>
        /// <param name="requestMessage">The requestMessage<see cref="HttpRequestMessage"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="ValueTask"/>.</returns>
        public override ValueTask BeforeHttpRequest(HttpRequestMessage requestMessage, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"calling {requestMessage.RequestUri}");
            return ValueTask.CompletedTask;
        }
    }
}

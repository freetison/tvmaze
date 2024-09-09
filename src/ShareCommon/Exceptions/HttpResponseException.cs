namespace TvMaze.ShareCommon.Exceptions
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Defines the <see cref="HttpResponseException" />.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class HttpResponseException : CustomException
    {
        /// <summary>
        /// Gets or sets the ErrorCode.
        /// </summary>
        public override int ErrorCode { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseException"/> class.
        /// </summary>
        /// <param name="problemDetails">The problemDetails.</param>
        public HttpResponseException(ProblemDetails? problemDetails)
        : base(problemDetails?.Title ?? "An error occurred", problemDetails ?? new ProblemDetails()) => ErrorCode = problemDetails?.Status ?? 500;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseException"/> class.
        /// </summary>
        /// <param name="code">The code<see cref="int"/>.</param>
        /// <param name="message">The message<see cref="string"/>.</param>
        public HttpResponseException(int code, string message)
        : base(code, message) => ErrorCode = code;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseException"/> class.
        /// </summary>
        /// <param name="code">The code<see cref="int"/>.</param>
        /// <param name="message">The message<see cref="string"/>.</param>
        /// <param name="inner">The inner<see cref="Exception"/>.</param>
        public HttpResponseException(int code, string message, Exception inner)
        : base(code, message, inner) => ErrorCode = code;
    }
}
namespace TvMaze.ShareCommon.Exceptions
{
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Defines the <see cref="CustomException" />.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class CustomException : Exception
    {
        /// <summary>
        /// Gets or sets the error code associated with the exception.
        /// </summary>
        public abstract int ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the ProblemDetails associated with the exception.
        /// </summary>
        public ProblemDetails? ProblemDetails { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        protected CustomException(string? message)
    : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="code">The error code associated with the exception.</param>
        /// <param name="message">The message that describes the error.</param>
        protected CustomException(int code, string message)
        : base(message)
        {
            HResult = code;
            ErrorCode = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="code">The error code associated with the exception.</param>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The exception that is the cause of the current exception.</param>
        protected CustomException(int code, string message, Exception inner)
        : base(message, inner)
        {
            HResult = code;
            ErrorCode = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="problemDetails">The ProblemDetails object with additional error information.</param>
        protected CustomException(string? message, ProblemDetails? problemDetails)
        : base(message)
        {
            ProblemDetails = problemDetails;
        }
    }
}
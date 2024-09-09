namespace TvMaze.ShareCommon.Exceptions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using FluentValidation.Results;

    /// <summary>
    /// Defines the <see cref="ValidationException" />.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ValidationException : CustomException
    {
        /// <summary>
        /// Defines the ERRORCODE.
        /// </summary>
        private const int ERRORCODE = (int)HttpStatusCode.PreconditionFailed;

        /// <summary>
        /// Defines the MESSAGE.
        /// </summary>
        private const string MESSAGE = "One or more validation failures have occurred.";

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        public ValidationException()
        : base(ERRORCODE, message: MESSAGE) => (HResult, Errors) = (ERRORCODE, new Dictionary<string, string[]>());

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="failures">The failures<see cref="IEnumerable{ValidationFailure}"/>.</param>
        public ValidationException(IEnumerable<ValidationFailure> failures)
        : this() => Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

        /// <summary>
        /// Gets the Errors.
        /// </summary>
        public IDictionary<string, string[]> Errors { get; }

        /// <summary>
        /// Gets or sets the ErrorCode.
        /// </summary>
        public override int ErrorCode { get; set; } = ERRORCODE;
    }
}
namespace TvMaze.ShareCommon.Exceptions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="ForbiddenAccessException" />.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ForbiddenAccessException : CustomException
    {
        /// <summary>
        /// Defines the ERRORCODE.
        /// </summary>
        private const int ERRORCODE = (int)HttpStatusCode.Forbidden;

        /// <summary>
        /// Defines the MESSAGE.
        /// </summary>
        private const string MESSAGE = "Without access to this resource";

        /// <summary>
        /// Gets or sets the ErrorCode.
        /// </summary>
        public override int ErrorCode { get; set; } = ERRORCODE;

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenAccessException"/> class.
        /// </summary>
        public ForbiddenAccessException()
        : base(ERRORCODE, MESSAGE) => HResult = ERRORCODE;

        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenAccessException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public ForbiddenAccessException(string message)
        : base(ERRORCODE, message) => HResult = ERRORCODE;
    }
}
namespace TvMaze.Application.Common.Exceptions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="NoConfigurationException" />.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class NoConfigurationException : CustomException
    {
        /// <summary>
        /// Defines the ERRORCODE.
        /// </summary>
        private const int ERRORCODE = (int)HttpStatusCode.InternalServerError;

        /// <summary>
        /// Defines the MESSAGE.
        /// </summary>
        private const string MESSAGE = "Without api configuration";

        /// <summary>
        /// Gets or sets the ErrorCode.
        /// </summary>
        public override int ErrorCode { get; set; } = ERRORCODE;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoConfigurationException"/> class.
        /// </summary>
        public NoConfigurationException()
        : base(ERRORCODE, MESSAGE) => HResult = ERRORCODE;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoConfigurationException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public NoConfigurationException(string message)
        : base(ERRORCODE, message) => HResult = ERRORCODE;
    }
}
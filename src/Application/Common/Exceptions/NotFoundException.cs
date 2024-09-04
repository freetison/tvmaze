namespace TvMaze.Application.Common.Exceptions
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="NotFoundException" />.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class NotFoundException : CustomException
    {
        /// <summary>
        /// Defines the ERRORCODE.
        /// </summary>
        private const int ERRORCODE = (int)HttpStatusCode.NotFound;

        /// <summary>
        /// Defines the MESSAGE.
        /// </summary>
        private const string MESSAGE = "Resource not found";

        /// <summary>
        /// Gets or sets the ErrorCode.
        /// </summary>
        public override int ErrorCode { get; set; } = ERRORCODE;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        public NotFoundException()
        : base(ERRORCODE, MESSAGE) => HResult = ERRORCODE;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public NotFoundException(string message)
        : base(ERRORCODE, message) => HResult = ERRORCODE;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="name">The name<see cref="string"/>.</param>
        /// <param name="key">The key<see cref="object"/>.</param>
        public NotFoundException(string name, object key)
        : base($"Entity '{name}' ({key}) was not found.")
        {
        }
    }
}
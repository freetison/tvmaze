using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace TvMaze.Application.Common.Exceptions;

[ExcludeFromCodeCoverage]
public class NoConfigurationException : CustomException
{
    private const int ERRORCODE = (int)HttpStatusCode.InternalServerError;
    private const string MESSAGE = "Without api configuration";

    public override int ErrorCode { get; set; } = ERRORCODE;

    public NoConfigurationException()
        : base(ERRORCODE, MESSAGE) => HResult = ERRORCODE;

    public NoConfigurationException(string message)
        : base(ERRORCODE, message) => HResult = ERRORCODE;
}
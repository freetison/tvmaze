using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace TvMaze.Application.Common.Exceptions;

[ExcludeFromCodeCoverage]
public class ForbiddenAccessException : CustomException
{
    private const int ERRORCODE = (int)HttpStatusCode.Forbidden;
    private const string MESSAGE = "Without access to this resource";

    public override int ErrorCode { get; set; } = ERRORCODE;

    public ForbiddenAccessException()
        : base(ERRORCODE, MESSAGE) => HResult = ERRORCODE;

    public ForbiddenAccessException(string message)
        : base(ERRORCODE, message) => HResult = ERRORCODE;
}

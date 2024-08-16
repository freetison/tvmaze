using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace TvMaze.Application.Common.Exceptions;

[ExcludeFromCodeCoverage]
public class NotFoundException : CustomException
{
    private const int ERRORCODE = (int)HttpStatusCode.NotFound;
    private const string MESSAGE = "Resource not found";

    public override int ErrorCode { get; set; } = ERRORCODE;

    public NotFoundException()
        : base(ERRORCODE, MESSAGE) => HResult = ERRORCODE;

    public NotFoundException(string message)
        : base(ERRORCODE, message) => HResult = ERRORCODE;

    public NotFoundException(string name, object key)
        : base($"Entity '{name}' ({key}) was not found.")
    {
    }
}
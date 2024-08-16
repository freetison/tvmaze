using System.Diagnostics.CodeAnalysis;

namespace TvMaze.Application.Common.Exceptions;

[ExcludeFromCodeCoverage]
public abstract class CustomException : Exception
{
    public CustomException(string? message)
        : base(message)
    {
    }

    protected CustomException(int code, string message)
        : base(message) => HResult = code;

    protected CustomException(int code, string message, Exception inner)
        : base(message, inner) => HResult = code;

    public abstract int ErrorCode { get; set; }
}

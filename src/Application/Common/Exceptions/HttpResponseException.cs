using System.Diagnostics.CodeAnalysis;

using Microsoft.AspNetCore.Mvc;

namespace TvMaze.Application.Common.Exceptions;

[ExcludeFromCodeCoverage]
public class HttpResponseException : CustomException
{
    public override int ErrorCode { get; set; }

    public HttpResponseException(ProblemDetails? problemDetails)
        : base(problemDetails?.Title ?? "An error occurred", problemDetails ?? new ProblemDetails()) => ErrorCode = problemDetails?.Status ?? 500;

    public HttpResponseException(int code, string message)
        : base(code, message) => ErrorCode = code;

    public HttpResponseException(int code, string message, Exception inner)
        : base(code, message, inner) => ErrorCode = code;
}

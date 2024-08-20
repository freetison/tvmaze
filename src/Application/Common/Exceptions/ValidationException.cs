using System.Diagnostics.CodeAnalysis;
using System.Net;

using FluentValidation.Results;

namespace TvMaze.Application.Common.Exceptions;

[ExcludeFromCodeCoverage]
public class ValidationException : CustomException
{
    private const int ERRORCODE = (int)HttpStatusCode.PreconditionFailed;
    private const string MESSAGE = "One or more validation failures have occurred.";

    public ValidationException()
        : base(ERRORCODE, message: MESSAGE) => (HResult, Errors) = (ERRORCODE, new Dictionary<string, string[]>());

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this() => Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

    public IDictionary<string, string[]> Errors { get; }
    public override int ErrorCode { get; set; } = ERRORCODE;
}
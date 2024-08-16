using System.Diagnostics.CodeAnalysis;

namespace TvMaze.Application.Common.Models.Settings
{
    [ExcludeFromCodeCoverage]
    public class ExternalApi
    {
        public required string BaseUrl { get; set; }
    }
}

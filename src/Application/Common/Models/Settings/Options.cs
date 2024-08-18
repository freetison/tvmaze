using System.Diagnostics.CodeAnalysis;

namespace TvMaze.Application.Common.Models.Settings
{
    [ExcludeFromCodeCoverage]
    public class Options
    {
        public bool UseInMemoryDatabase { get; set; } = false;
        public int RequestLimitPerMinutes { get; set; } = 100;
        public string ApiKey { get; set; } = string.Empty;
    }
}

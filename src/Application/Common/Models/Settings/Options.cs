namespace TvMaze.Application.Common.Models.Settings
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class Options
    {
        public bool UseInMemoryDatabase { get; set; } = false;
        public int RequestLimitPerMinutes { get; set; } = 100;
        public string ApiKey { get; set; } = string.Empty;
    }
}

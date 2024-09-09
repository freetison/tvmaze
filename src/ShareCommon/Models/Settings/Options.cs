namespace TvMaze.ShareCommon.Models.Settings
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class Options
    {
        public bool UseInMemoryDatabase { get; set; } = false;
        public int RequestLimitPerMinutes { get; set; } = 100;
        public int RequestRateSeconds { get; set; } = 10;
        public string ApiKey { get; set; } = string.Empty;
    }
}
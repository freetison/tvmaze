namespace TvMaze.Application.Common.Models.Settings
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class ExternalApi
    {
        required public string BaseUrl { get; set; }
    }
}

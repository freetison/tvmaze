using System.Diagnostics.CodeAnalysis;

namespace TvMaze.Application.Common.Models.Settings
{
    [ExcludeFromCodeCoverage]
    public class Options
    {
        public bool UseInMemoryDatabase { get; set; } = false;
    }
}

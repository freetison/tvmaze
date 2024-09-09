namespace TvMaze.ShareCommon.Models.Settings
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class Credentials
    {
        required public string User { get; set; }
        required public string PassWord { get; set; }
    }
}

// ReSharper disable InconsistentNaming
namespace TvMaze.HttpServiceProvider.Models.RapidApi;

public class Query
{
    public string? from { get; set; }
    public string? to { get; set; }
    public double amount { get; set; }
}
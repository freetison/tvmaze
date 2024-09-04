// ReSharper disable InconsistentNaming
namespace TvMaze.HttpServiceProvider.Models.Telegram;

public class GetMeResponse
{
    public bool ok { get; set; }
    public GetMeResult? result { get; set; }
}
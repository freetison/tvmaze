// ReSharper disable InconsistentNaming

using Newtonsoft.Json;

namespace TvMaze.HttpServiceProvider.Models.Telegram;

public class UpdateResponse
{
    public int update_id { get; set; }

    [JsonProperty("message")]
    public UpdateMessage? message { get; set; }
}
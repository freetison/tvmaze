﻿// ReSharper disable InconsistentNaming
namespace TvMaze.HttpServiceProvider.Models.Telegram;

public class GetMeResult
{
    public long id { get; set; }
    public bool is_bot { get; set; }
    public string? first_name { get; set; }
    public string? username { get; set; }
    public bool can_join_groups { get; set; }
    public bool can_read_all_group_messages { get; set; }
    public bool supports_inline_queries { get; set; }
    public bool can_connect_to_business { get; set; }
}
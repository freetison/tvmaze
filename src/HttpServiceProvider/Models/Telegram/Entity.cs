﻿// ReSharper disable InconsistentNaming
namespace TvMaze.HttpServiceProvider.Models.Telegram;

public class Entity
{
    public int offset { get; set; }
    public int length { get; set; }
    public string? type { get; set; }
}
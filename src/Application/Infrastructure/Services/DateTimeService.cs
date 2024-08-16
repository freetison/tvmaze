using TvMaze.Application.Common.Interfaces;

namespace TvMaze.Application.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
using System.Globalization;

using CsvHelper.Configuration;

using TvMaze.Application.Domain.Todos;

namespace TvMaze.Application.Infrastructure.Files;

public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
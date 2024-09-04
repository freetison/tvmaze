namespace TvMaze.Application.Common;

public interface IHasDomainEvent
{
    public List<DomainEvent> DomainEvents { get; }
}

namespace Contracts;

public interface IEvent
{
    public Guid EventId => Guid.NewGuid();
    public DateTime EventCreatedAtUtc => DateTime.UtcNow;
}
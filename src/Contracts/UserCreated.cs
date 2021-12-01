namespace Contracts;

public record UserCreated : IEvent
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
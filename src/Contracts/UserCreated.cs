namespace Contracts;

public class UserCreated : IEvent
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
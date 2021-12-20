namespace Contracts;

public class OrderCreated : IEvent
{
    public Guid Id { get; set; }
}
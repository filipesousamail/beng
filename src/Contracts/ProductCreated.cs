namespace Contracts;

public class ProductCreated : IEvent
{
    public Guid Id { get; set; }
}
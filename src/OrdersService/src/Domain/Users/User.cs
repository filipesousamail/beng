namespace beng.OrdersService.Domain.Users;

public class User : AggregateRoot<Guid>
{
    public User() => Id = Guid.NewGuid();

    public string Name { get; set; }
}
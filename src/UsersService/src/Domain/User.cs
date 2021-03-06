namespace beng.UsersService.Domain;

public class User : AggregateRoot<Guid>
{
    public User() => Id = Guid.NewGuid();

    public string Name { get; set; }
}
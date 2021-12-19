namespace beng.UsersService.Domain;

public class User : Entity<Guid>
{
    public User()
    {
        Id = Guid.NewGuid();
    }
    
    public string Name { get; set; }
}
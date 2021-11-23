namespace beng.OrdersService.Domain;

public class Product : Entity<Guid>
{
    public Product()
    {
        Orders = new List<Order>();
    }
    
    public List<Order> Orders { get; set; }
}
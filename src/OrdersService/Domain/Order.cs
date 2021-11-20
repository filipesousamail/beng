namespace beng.OrdersService.Domain;

public class Order
{
    public Order()
    {
        ProductIds = new List<Guid>();
    }

    public Guid Id { get; set; }
    public decimal Total { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }

    public List<Guid> ProductIds { get; set; }
}
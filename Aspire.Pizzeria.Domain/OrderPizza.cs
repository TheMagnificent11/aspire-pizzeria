namespace Aspire.Pizzeria.Domain;

public class OrderPizza
{
    public Guid OrderId { get; set; }

    public Order Order { get; set; }

    public int PizzaId { get; set; }

    public Pizza Pizza { get; set; }

    public int Quantity { get; set; }
}

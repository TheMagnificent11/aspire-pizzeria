namespace Aspire.Pizzeria.Domain;

public class Order
{
    public Order(string customerName, string deliveryAddress, Pizza[] pizzas)
    {
        this.Id = Guid.NewGuid();
        this.OrderDate = DateTime.UtcNow;

        this.CustomerName = customerName;
        this.DeliveryAddress = deliveryAddress;

        this.Pizzas = pizzas
            .GroupBy(pizza => pizza.Id)
            .Select(group => new OrderPizza
            {
                Pizza = group.First(),
                Quantity = group.Count()
            })
            .ToList()
            .AsReadOnly();
    }

    // EF Constructor
    private Order()
    {
    }

    public Guid Id { get; protected set; }

    public DateTime OrderDate { get; protected set; }

    public string CustomerName { get; protected set; }

    public string DeliveryAddress { get; protected set; }

    public IReadOnlyCollection<OrderPizza> Pizzas { get; protected set; }

    public decimal TotalPrice => this.Pizzas.Sum(x => x.Pizza.Price * x.Quantity);

    public bool IsPrepared { get; protected set; }

    public DateTime? PreparationDate { get; protected set; }

    public bool IsDelivered { get; protected set; }

    public DateTime? DeliveryDate { get; protected set; }

    public void PizzasPrepared()
    {
        if (this.IsPrepared)
        {
            return;
        }

        this.IsPrepared = true;
        this.PreparationDate = DateTime.UtcNow;
    }

    public void PizzasDelivered()
    {
        if (!this.IsPrepared)
        {
            throw new InvalidOperationException("Cannot deliver an order that is not prepared.");
        }

        if (this.IsDelivered)
        {
            return;
        }

        this.IsDelivered = true;
        this.DeliveryDate = DateTime.UtcNow;
    }

    public static class FieldLengths
    {
        public const int CustomerName = 100;
        public const int DeliveryAddress = 200;
    }
}

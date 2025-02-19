namespace Aspire.Pizzeria.PizzaStore.Contracts;

public record PlacedOrderCommand(string CustomerName, string DeliveryAddress)
{
    private readonly List<int> pizzaIds = [];

    public IReadOnlyCollection<int> PizzaIds => this.pizzaIds;

    public void AddPizza(int pizzaId)
    {
        this.pizzaIds.Add(pizzaId);
    }
}

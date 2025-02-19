namespace Aspire.Pizzeria.PizzaStore.Contracts;

public interface IOrderPizzaRequest
{
    string CustomerName { get; }

    bool IsDelivery { get; }

    string? DeliveryAddress { get; }

    IReadOnlyCollection<int> PizzaIds { get; }
}

namespace Aspire.Pizzeria.PizzaStore.Contracts;

public class OrderPizzaRequestV1 : IOrderPizzaRequest
{
    public string CustomerName { get; set; } = string.Empty;

    public bool IsDelivery { get; set; }

    public string? DeliveryAddress { get; set; }

    public IReadOnlyCollection<int> PizzaIds { get; set; } = [];
}

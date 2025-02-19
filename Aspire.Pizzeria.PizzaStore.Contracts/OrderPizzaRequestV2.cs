namespace Aspire.Pizzeria.PizzaStore.Contracts;

public sealed class OrderPizzaRequestV2 : IOrderPizzaRequest
{
    private OrderPizzaRequestV2(string customerName, bool isDelivery, string? deliveryAddress, params int[] pizzaIds)
    {
        this.CustomerName = customerName;
        this.IsDelivery = isDelivery;
        this.DeliveryAddress = deliveryAddress;
        this.PizzaIds = pizzaIds;
    }

    public string CustomerName { get; }

    public bool IsDelivery { get; }

    public string? DeliveryAddress { get; }

    public IReadOnlyCollection<int> PizzaIds { get; }

    public static OrderPizzaRequestV2 CreatePickupOrder(string customerName, params int[] pizzaIds)
    {
        return new OrderPizzaRequestV2(
            customerName,
            isDelivery: false,
            deliveryAddress: null,
            pizzaIds);
    }

    public static OrderPizzaRequestV2 CreateDeliveryOrder(string customerName, string deliveryAddress, params int[] pizzaIds)
    {
        return new OrderPizzaRequestV2(
            customerName,
            isDelivery: true,
            deliveryAddress,
            pizzaIds);
    }
}

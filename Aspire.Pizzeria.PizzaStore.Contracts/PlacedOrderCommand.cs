namespace Aspire.Pizzeria.PizzaStore.Contracts;

public record PlacedOrderCommand(string CustomerName, string DeliveryAddress, int[] PizzaIds);

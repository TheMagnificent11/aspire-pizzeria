namespace Aspire.Pizzeria.PizzaStore.Orders;

#pragma warning disable SA1313 // Parameter names should begin with lower-case letter
public record PlaceOrderCommand(string CustomerName, string DeliveryAddress, int[] PizzaIds);
#pragma warning restore SA1313 // Parameter names should begin with lower-case letter

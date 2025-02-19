using System.Diagnostics.CodeAnalysis;

namespace Aspire.Pizzeria.PizzaStore.Contracts;

[SuppressMessage("" +
    "Info Code Smell",
    "S1133:Deprecated code should be removed",
    Justification = "Will remove in a future release after consumers have upgraded")]
[Obsolete(
    "This version of the request is deprecated. Please use OrderPizzaRequestV2 instead.",
    error: false)]
public class OrderPizzaRequestV1 : IOrderPizzaRequest
{
    public string CustomerName { get; set; } = string.Empty;

    public bool IsDelivery { get; set; }

    public string? DeliveryAddress { get; set; }

    public IReadOnlyCollection<int> PizzaIds { get; set; } = [];
}

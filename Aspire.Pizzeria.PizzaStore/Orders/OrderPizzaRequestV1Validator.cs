using System.Diagnostics.CodeAnalysis;
using Aspire.Pizzeria.PizzaStore.Contracts;

namespace Aspire.Pizzeria.PizzaStore.Orders;

[SuppressMessage(
    "Info Code Smell",
    "S1133:Deprecated code should be removed",
    Justification = "Will remove in a future relase after consumers have upgraded")]
[Obsolete(
    "This version of the request is deprecated. Please use OrderPizzaRequestV2Validator instead.",
    error: false)]
public sealed class OrderPizzaRequestV1Validator : OrderPizzaRequestValidator<OrderPizzaRequestV1>
{
    public OrderPizzaRequestV1Validator()
        : base()
    {
    }
}

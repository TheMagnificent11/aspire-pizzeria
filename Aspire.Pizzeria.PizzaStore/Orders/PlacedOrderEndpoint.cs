using FastEndpoints;

namespace Aspire.Pizzeria.PizzaStore.Orders;

public sealed class PlacedOrderEndpoint : Endpoint<PlaceOrderCommand, EmptyResponse>
{
    public override void Configure()
    {
        this.Post("/orders");
        this.AllowAnonymous();
        this.Validator<PlaceOrderCommandValidator>();
        this.Description(x =>
        {
            var builder = x.WithName("PlaceOrder");

            builder.ProducesProblemDetails();
        });
    }

    public override Task HandleAsync(PlaceOrderCommand req, CancellationToken ct)
    {
        return base.HandleAsync(req, ct);
    }
}

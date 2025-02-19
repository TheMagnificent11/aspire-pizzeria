using Aspire.Pizzeria.Data;
using Aspire.Pizzeria.PizzaStore.Contracts;
using FastEndpoints;

namespace Aspire.Pizzeria.PizzaStore.Orders;

public sealed class PlacedOrderEndpoint : Endpoint<PlacedOrderCommand, EmptyResponse>
{
    private readonly PizzeriaDbContext dbContext;

    public PlacedOrderEndpoint(PizzeriaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

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

    public override async Task HandleAsync(PlacedOrderCommand req, CancellationToken ct)
    {
        var pizzas = Domain.Menu.Pizzas
            .Where(x => req.PizzaIds.Contains(x.Id))
            .ToArray();

        var order = new Domain.Order(req.CustomerName, req.DeliveryAddress, pizzas);

        this.dbContext.Orders.Add(order);

        await this.dbContext.SaveChangesAsync(ct);
    }
}

using Aspire.Pizzeria.Data;
using Aspire.Pizzeria.PizzaStore.Contracts;
using FastEndpoints;

namespace Aspire.Pizzeria.PizzaStore.Orders;

public sealed class OrderPizzaEndpoint : Endpoint<IOrderPizzaRequest, EmptyResponse>
{
    private readonly PizzeriaDbContext dbContext;
    private readonly ILogger<OrderPizzaEndpoint> logger;

    public OrderPizzaEndpoint(PizzeriaDbContext dbContext, ILogger<OrderPizzaEndpoint> logger)
    {
        this.dbContext = dbContext;
        this.logger = logger;
    }

    public override void Configure()
    {
        this.Post("/orders");
        this.AllowAnonymous();
    }

    public override async Task HandleAsync(IOrderPizzaRequest req, CancellationToken ct)
    {
        if (!req.IsDelivery || string.IsNullOrWhiteSpace(req.DeliveryAddress))
        {
            throw new NotSupportedException("Only delivery orders are supported.");
        }

        var pizzas = Domain.Menu.Pizzas
            .Where(x => req.PizzaIds.Contains(x.Id))
            .ToArray();

        var order = new Domain.Order(req.CustomerName, req.DeliveryAddress, pizzas);

        this.dbContext.Orders.Add(order);

        await this.dbContext.SaveChangesAsync(ct);

        this.logger.LogInformation(
            "Order placed for {CustomerName} with {PizzaCount} pizzas.",
            req.CustomerName,
            pizzas.Length);
    }
}

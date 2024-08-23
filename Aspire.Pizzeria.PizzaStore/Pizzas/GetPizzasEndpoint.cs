using Aspire.Pizzeria.Domain;
using FastEndpoints;

namespace Aspire.Pizzeria.PizzaStore.Pizzas;

public sealed class GetPizzasEndpoint : Endpoint<EmptyRequest, Pizza[]>
{
    public override void Configure()
    {
        this.Get("/pizzas");
        this.AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var pizzas = Menu.Pizzas;

        await this.SendOkAsync(pizzas);
    }
}

using Aspire.Pizzeria.Domain;
using Aspire.Pizzeria.PizzaStore.Contracts;
using FastEndpoints;

namespace Aspire.Pizzeria.PizzaStore.Pizzas;

public sealed class GetPizzasEndpoint : Endpoint<EmptyRequest, PizzaDto[]>
{
    public override void Configure()
    {
        this.Get("/pizzas");
        this.AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var pizzas = Menu.Pizzas
            .Select(x => new PizzaDto(x.Id, x.Name, x.Description, x.Price))
            .ToArray();

        await this.SendOkAsync(pizzas, ct);
    }
}

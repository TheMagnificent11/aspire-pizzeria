using System.Net.Http.Json;
using Aspire.Pizzeria.PizzaStore.Contracts;

namespace Aspire.Pizzeria.PizzaStore.Client;

public sealed class OrdersHttpClient
{
    private readonly HttpClient httpClient;

    public OrdersHttpClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task OrderPizzaV1Async(OrderPizzaRequestV1 orderPizzaRequest)
    {
        var response = await this.httpClient.PostAsJsonAsync("/orders", orderPizzaRequest);

        response.EnsureSuccessStatusCode();
    }

    public async Task OrderPizzaV2Async(OrderPizzaRequestV2 orderPizzaRequest)
    {
        var response = await this.httpClient.PostAsJsonAsync("/orders", orderPizzaRequest);

        response.EnsureSuccessStatusCode();
    }
}

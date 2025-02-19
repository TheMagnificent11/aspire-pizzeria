using System.Diagnostics.CodeAnalysis;
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

    [SuppressMessage(
        "Info Code Smell",
        "S1133:Deprecated code should be removed",
        Justification = "Will remove in a future release after consumers have upgraded")]
    [Obsolete(
        "This version of the request is deprecated. Please use OrderPizzaV2Async instead.",
        error: false)]
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

namespace Aspire.Pizzeria.PizzaStore.Contracts;

public class PizzaDto
{
    public PizzaDto(
        int id,
        string name,
        string description,
        decimal price)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.Price = price;
    }

    public int Id { get; }

    public string Name { get; }

    public string Description { get; }

    public decimal Price { get; }
}

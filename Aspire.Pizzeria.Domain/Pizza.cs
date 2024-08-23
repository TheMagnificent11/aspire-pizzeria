namespace Aspire.Pizzeria.Domain;

public class Pizza
{
    public Pizza(int id, string name, string description, decimal price)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.Price = price;
    }

    // EF Constructor
    private Pizza()
    {
    }

    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public decimal Price { get; protected set; }
    public IReadOnlyCollection<OrderPizza> OrderPizzas { get; protected set; }

    public static class FieldLengths
    {
        public const int Name = 25;
        public const int Description = 500;
    }
}

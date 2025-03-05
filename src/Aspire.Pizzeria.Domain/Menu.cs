namespace Aspire.Pizzeria.Domain;

public static class Menu
{
    public static class PizzaNames
    {
        public const string Margherita = nameof(Margherita);

        public const string Marinara = nameof(Marinara);

        public const string QuattroStagioni = "Quattro Stagioni";

        public const string Carbonara = nameof(Carbonara);

        public const string FruttiDiMare = "Frutti di Mare";

        public const string QuattroFormaggi = "Quattro Formaggi";

        public const string Crudo = nameof(Crudo);

        public const string Napoletana = nameof(Napoletana);

        public const string Pugliese = nameof(Pugliese);

        public const string Montanara = nameof(Montanara);
    }

    public static readonly Pizza[] Pizzas =
    [
        new(
            1,
            PizzaNames.Margherita,
            "Tomato sauce, mozzarella, and oregano",
            5.00m),

        new(2,
            PizzaNames.Marinara,
            "Tomato sauce, garlic and basil",
            5.50m),

        new(
            3,
            PizzaNames.QuattroStagioni,
            "Tomato sauce, mozzarella, mushrooms, ham, artichokes, olives, and oregano",
            8.00m),

        new(
            4,
            PizzaNames.Carbonara,
            "Tomato sauce, mozzarella, parmesan, eggs, and bacon",
            8.50m),

        new(
            5,
            PizzaNames.FruttiDiMare,
            "Tomato sauce and seafood",
            8.50m),

        new(
            6,
            PizzaNames.QuattroFormaggi,
            "Tomato sauce, mozzarella, parmesan, gorgonzola cheese, artichokes, and oregano",
            8.50m),

        new(
            7,
            PizzaNames.Crudo,
            "Tomato sauce, mozzarella, Parma ham, parmesan, mushrooms, and oregano",
            9.00m),

        new(
            8,
            PizzaNames.Napoletana,
            "Tomato sauce, mozzarella, oregano, anchovies",
            9.00m),

        new(
            9,
            PizzaNames.Pugliese,
            "Tomato sauce, mozzarella, oregano, and onions",
            9.00m),

        new(
            10,
            PizzaNames.Montanara,
            "Tomato sauce, mozzarella, mushrooms, pepperoni, and oregano",
            9.00m)
    ];

    public static Pizza GetPizzaByName(string name)
    {
        return Pizzas.Single(x => x.Name == name);
    }
}

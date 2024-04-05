using System;
using System.Collections.Generic;

class Coffee
{
    private List<string> ingredients = new List<string>();

    public Coffee(string baseCoffee)
    {
        ingredients.Add(baseCoffee);
    }

    public void AddIngredient(string ingredient)
    {
        ingredients.Add(ingredient);
    }

    public override string ToString()
    {
        if (ingredients.Count == 0)
            return "No ingredients";

        return string.Join(" + ", ingredients);
    }
}

interface ICoffeeBuilder
{
    void AddMilk(string milkType);
    void AddSugar(int amount);
    Coffee Build();
}

class CoffeeBuilder : ICoffeeBuilder
{
    private Coffee coffee;

    public CoffeeBuilder()
    {
        coffee = new Coffee("Black coffee");
    }

    public void AddMilk(string milkType)
    {
        coffee.AddIngredient(milkType);
    }

    public void AddSugar(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            coffee.AddIngredient("Sugar");
        }
    }

    public Coffee Build()
    {
        return coffee;
    }
}



class Program
{
    static void Main(string[] args)
    {
        CoffeeBuilder espressoBuilder = new CoffeeBuilder();
        Coffee espresso = espressoBuilder.Build();
        Console.WriteLine("Espresso: " + espresso);

        CoffeeBuilder cappuccinoBuilder = new CoffeeBuilder();
        cappuccinoBuilder.AddSugar(1);
        cappuccinoBuilder.AddMilk("Oat milk");
        Coffee cappuccino = cappuccinoBuilder.Build();
        Console.WriteLine("Cappuccino: " + cappuccino);

        CoffeeBuilder flatWhiteBuilder= new CoffeeBuilder();
        flatWhiteBuilder.AddMilk("Soy milk");
        flatWhiteBuilder.AddMilk("Soy milk");
        flatWhiteBuilder.AddSugar(1);
        Coffee flatWhite = flatWhiteBuilder.Build();
        Console.WriteLine("Flat White: " + flatWhite);

        CoffeeBuilder customBuilder = new CoffeeBuilder();
        customBuilder.AddSugar(3);
        customBuilder.AddMilk("Soy milk");
        customBuilder.AddMilk("Regular milk"); 
        Coffee customCoffee = customBuilder.Build();
        Console.WriteLine("Custom Coffee: " + customCoffee);
    }
}

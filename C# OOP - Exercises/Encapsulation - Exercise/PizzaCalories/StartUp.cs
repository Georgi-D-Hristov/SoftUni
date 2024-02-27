using PizzaCalories;
using PizzaCalories.DoughModels;

public class StartUp
{
    private static void Main(string[] args)
    {
        try
        {
            string[] pizzaInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string pizzaName = pizzaInfo[1];

            string[] doughInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string flourType = doughInfo[1];
            string bakingTechnique = doughInfo[2];
            int weigh = int.Parse(doughInfo[3]);

            Dough dough = new(flourType, bakingTechnique, weigh);

            Pizza pizza = new(pizzaName, dough);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string toppingType = commandArgs[1];
                int weight = int.Parse(commandArgs[2]);
                Topping topping = new(toppingType, weight);
                pizza.AddTopping(topping);
            }
            Console.WriteLine($"{pizzaName} - {pizza.GetTotalCalories():f2} Calories.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }
    }
}
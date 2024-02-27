using PizzaCalories;
using PizzaCalories.DoughModels;
using System.ComponentModel;

public class StartUp
{
    private static void Main(string[] args)
    {
        try
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string ingredient = commandArgs[0];
                string ingredientType = commandArgs[1];


                if (ingredient == "Dough")
                {
                    string bakingTechnique = commandArgs[2];
                    int weigh = int.Parse(commandArgs[3]);
                    Dough dough = new(ingredientType, bakingTechnique, weigh);
                    Console.WriteLine(dough.GetCalories().ToString("f2"));
                }
                else if (ingredient == "Topping")
                {
                    int weight = int.Parse(commandArgs[2]);
                    Topping topping = new(ingredientType, weight);
                    Console.WriteLine(topping.GetCalories().ToString("f2"));
                }

            }


        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }

    }
}
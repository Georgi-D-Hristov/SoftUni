using PizzaCalories.DoughModels;

public class StartUp
{
    private static void Main(string[] args)
    {
        try
        {
            var dough = new Dough("banica", "sirene", 100);
        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }

    }
}
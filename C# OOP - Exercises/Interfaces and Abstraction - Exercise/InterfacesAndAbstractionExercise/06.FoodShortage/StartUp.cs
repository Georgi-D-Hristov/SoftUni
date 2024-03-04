namespace _06.FoodShortage;

public class StartUp
{
    public static void Main(string[] args)
    {
        var numberOfPeople = int.Parse(Console.ReadLine());

        var people = new List<IBuyer>();

        for (int i = 0; i < numberOfPeople; i++)
        {
            var inputLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var name = inputLine[0];
            if (inputLine.Length == 4)
            {
                var citizen = new Citizen(name);
                people.Add(citizen);
            }

            if (inputLine.Length == 3)
            {
                var rebel = new Rebel(name);
                people.Add(rebel);
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var name = command;
            var person = people.FirstOrDefault(p => p.Name == name);
            if (person != null)
            {
                person.BuyFood();
            }
        }

        var totalFood = 0;
        foreach (var person in people)
        {
            totalFood += person.GetTotalFood();
        }

        Console.WriteLine(totalFood);
    }
}
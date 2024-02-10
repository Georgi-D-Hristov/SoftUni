namespace DefiningClasses;

public class StartUp
{
    public static void Main(string[] args)
    {
        var number = int.Parse(Console.ReadLine());

        var family = new Family();

        for (int i = 0; i < number; i++)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var name = input[0];
            var age = int.Parse(input[1]);
            
            var person = new Person(name, age);
            family.AddMember(person);
        }
        Console.WriteLine(family.GetOldestMember());
    }
}


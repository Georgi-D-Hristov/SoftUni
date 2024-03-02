namespace _05.BirthdayCelebrations;

public class StartUp
{
    public static void Main()
    {
        string input;

        var birthable = new List<IBirthable>();

        while ((input = Console.ReadLine()) != "End")
        {
            var inputLine = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var inputType = inputLine[0];

            switch (inputType)
            {
                case "Citizen":
                    birthable.Add(new Citizen(inputLine[1], int.Parse(inputLine[2]), inputLine[3], inputLine[4]));
                    break;

                case "Robot":
                    break;

                case "Pet":
                    birthable.Add(new Pet(inputLine[1], (inputLine[2])));
                    break;
            }
        }

        var searchYear = Console.ReadLine();

        foreach (var member in birthable)
        {
            if (member.Birthday.EndsWith(searchYear))
            {
                Console.WriteLine(member.Birthday);
            }
        }
    }
}
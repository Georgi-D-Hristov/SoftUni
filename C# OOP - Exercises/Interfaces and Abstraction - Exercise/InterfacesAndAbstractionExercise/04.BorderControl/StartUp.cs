namespace _04.BorderControl;

public class StartUp
{
    public static void Main(string[] args)
    {
        var visitors = new List<IVisitors>();

        string inputLines;

        while ((inputLines = Console.ReadLine()) != "End")
        {
            var inputInfo = inputLines
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (inputInfo.Length == 3)
            {
                var citizenName = inputInfo[0];
                var citizenAge = int.Parse(inputInfo[1]);
                var citizenId = inputInfo[2];

                var citizen = new Citizen(citizenName, citizenAge, citizenId);
                visitors.Add(citizen);
            }

            if (inputInfo.Length == 2)
            {
                var robotModel = inputInfo[0];
                var robotId = inputInfo[1];

                var robot = new Robot(robotModel, robotId);
                visitors.Add(robot);
            }
        }

        var pattern = Console.ReadLine();

        foreach (var visitor in visitors)
        {
            visitor.ValidateId(pattern);
        }
    }
}
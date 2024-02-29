namespace _05.FootballGenerator;

public class Program
{
    public static void Main(string[] args)
    {
        string commandInput;
        List<Team> teams = new();

        while ((commandInput = Console.ReadLine()) != "END")
        {
            string[] commandArgs = commandInput
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            string command = commandArgs[0];
            string teamName = commandArgs[1];

            try
            {
                switch (command)
                {
                    case "Team":
                        Team team = new(teamName);
                        teams.Add(team);
                        break;

                    case "Add":
                        if (!teams.Any(t => t.Name == teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            string playerName = commandArgs[2];
                            Player player = new Player(playerName, int.Parse(commandArgs[3]), int.Parse(commandArgs[4]), int.Parse(commandArgs[5]), int.Parse(commandArgs[6]), int.Parse(commandArgs[7]));
                            teams.Where(t => t.Name == teamName).First().AddPlayer(player);
                        }
                        break;

                    case "Remove":
                        string playerNameToRemove = commandArgs[2];

                        if (teams.First(t => t.Name == teamName).Players.Any(p => p.Name == playerNameToRemove))
                        {
                            teams.First(t => t.Name == teamName).RemovePlayer(teams.First(t => t.Name == teamName).Players.First(p => p.Name == playerNameToRemove));
                        }
                        else
                        {
                            Console.WriteLine($"Player {playerNameToRemove} is not in {teamName} team.");
                        }
                        break;

                    case "Rating":
                        if (!teams.Any(t => t.Name == teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            decimal rating = teams.First(t => t.Name == teamName).CalculateRating();
                            Console.WriteLine($"{teamName} - {rating}");
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
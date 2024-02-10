namespace _05.DateModifier;

public class StartUp
{
    public static void Main(string[] args)
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        var dates = new Date(firstDate, secondDate);
        var result = dates.GetDateDifference();
        Console.WriteLine(result);
    }
}

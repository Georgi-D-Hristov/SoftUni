namespace _03.Telephony;

public class StartUp
{
    public static void Main(string[] args)
    {
        string[] numbersInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
        string[] urlsInfo = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        Smartphone smartphone = new();
        StationaryPhone stationaryPhone = new();

        foreach (string number in numbersInfo)
        {
            stationaryPhone.Calling(number);
        }

        foreach (string url in urlsInfo)
        {
           
            smartphone.Browsing(url);
        }
    }
    
}

using System.Security.Cryptography;

var fuelInfo = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
var consumptionInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
var quatitiesInfo = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

var fuel = new Stack<int>(fuelInfo);
var consumption = new Queue<int>(consumptionInfo);
var quatities = new Queue<int>(quatitiesInfo);

var altitudeCount = quatities.Count;
var currentAltitude = 0;
var reachAltitude = 0;
var listOfReachAltitude = new List<string>();

while (fuel.Count>0)
{
    currentAltitude++;
    var currentFuel = fuel.Pop();
    var currentConsumption = consumption.Dequeue();
    var currentQuantities = quatities.Dequeue();

    if ((currentFuel-currentConsumption)<currentQuantities)
    {
        Console.WriteLine($"John did not reach: Altitude {currentAltitude}");
        break;
    }
    Console.WriteLine($"John has reached: Altitude {currentAltitude}");
    reachAltitude++;
    listOfReachAltitude.Add($"Altitude {reachAltitude}");
}
if (reachAltitude!=altitudeCount)
{
    Console.WriteLine("John failed to reach the top.");
    if (listOfReachAltitude.Count>0)
    {
        Console.WriteLine($"Reached altitudes: {String.Join(", ", listOfReachAltitude)}");
    }
    else
    {
        Console.WriteLine("John didn't reach any altitude.");
    }
    
}
else
{
    Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
}



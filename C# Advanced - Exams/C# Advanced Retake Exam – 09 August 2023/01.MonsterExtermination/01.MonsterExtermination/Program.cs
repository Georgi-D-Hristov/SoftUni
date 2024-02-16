var armorInfo = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

var soldersInfo = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

var armors = new Queue<int>(armorInfo);
var solders = new Stack<int>(soldersInfo);
var killedMonsters = 0;

while (solders.Count > 0 && armors.Count > 0)
{
    var armor = armors.Dequeue();
    var solder = solders.Pop();

    var attack = solder - armor;

    if (attack >= 0)
    {
        killedMonsters++;
        if (solders.Count > 0)
        {
            solders.Push(solders.Pop() + attack);
        }
    }
    if (attack < 0)
    { 
            armors.Enqueue(Math.Abs(attack));
        
    }
}
if (!armors.Any())
{
    Console.WriteLine("All monsters have been killed!");

}
if(!solders.Any())
{
    Console.WriteLine("The soldier has been defeated.");
}
Console.WriteLine($"Total monsters killed: {killedMonsters}");
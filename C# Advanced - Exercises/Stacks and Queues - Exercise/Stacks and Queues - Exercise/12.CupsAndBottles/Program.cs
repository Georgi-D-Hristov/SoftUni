var inputCupsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
var inputFilledBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

var cups = new Queue<int>();
var bottles = new Stack<int>();

var wastedLittersOfWater = 0;

foreach (var cup in inputCupsCapacity)
{
    cups.Enqueue(cup);
}

foreach (var bottle in inputFilledBottles)
{ 
    bottles.Push(bottle); 
}

while (cups.Count!=0&&bottles.Count!=0)
{
    if (bottles.Peek() - cups.Peek()>=0)
    {
        wastedLittersOfWater += (bottles.Peek() - cups.Peek());
        cups.Dequeue();
        bottles.Pop();
    }
    else
    {
        var cup = cups.Peek();
        var bottle = bottles.Peek();
        while (cup>0)
        {
            cup -= bottle;
         
            bottles.Pop();
            if (!bottles.Any())
            {
                break;
            }
            bottle = bottles.Peek();
            if (bottle >= cup)
            {
                wastedLittersOfWater += (bottle - cup);
                bottles.Pop();
                cups.Dequeue();
                break;
            }
        }
    }
}

if (cups.Count==0)
{
    Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
    Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
}
else
{
    Console.WriteLine($"Cups: {string.Join(" ", cups)}");
    Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
}

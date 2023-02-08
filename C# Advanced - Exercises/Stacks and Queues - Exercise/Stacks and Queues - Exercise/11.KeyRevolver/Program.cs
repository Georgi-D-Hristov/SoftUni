var bulletPrice = int.Parse(Console.ReadLine());
var sizeOfGunBarrel = int.Parse(Console.ReadLine());
var inputBullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
var inputLocks = Console.ReadLine().Split().Select(int.Parse).ToArray();
var intelligence = int.Parse(Console.ReadLine());

var shots = 0;

var bullets = new Stack<int>();
var locks = new Queue<int>();

foreach (var bullet in inputBullets)
{
    bullets.Push(bullet);
}
foreach (var item in inputLocks)
{
    locks.Enqueue(item);
}

while (bullets.Count!=0&&locks.Count!=0)
{
    if (bullets.Peek()<=locks.Peek())
    {
        Console.WriteLine("Bang!");
        bullets.Pop();
        locks.Dequeue();
        shots++;
     
    }
    else 
    {
        Console.WriteLine("Ping!");
        bullets.Pop();
        shots++;
    }

    if (shots==sizeOfGunBarrel)
    {
        if (bullets.Count==0)
        {
            break;
        }
        Console.WriteLine("Reloading!");
        shots = 0;
        if (locks.Count == 0)
        {
            break;
        }
    }
}

if (locks.Count==0)
{
    var moneyEarned = intelligence - (bulletPrice * (inputBullets.Length-bullets.Count));
    Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
}
else
{
    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
}